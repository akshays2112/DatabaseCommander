/*
    Created by Akshay Srinivasan [akshays2112@gmail.com]
    This javascript code is provided as is with no warranty implied.
    Akshay Srinivasan is not liable or responsible for any consequence of 
    using this code in your applications.
    You are free to use it and/or change it for both commercial and non-commercial
    applications as long as you give credit to Akshay Srinivasan the creator 
    of this code.
*/

"use strict";

//TreeView code starts here

var treeViewPropsArray = new Array();

var Treeview = function () { };
var TreeviewNode = function () { };
var TreeviewProps = function () { };
var ClickExtent = function () { };

Treeview.prototype = {
    CanvasID: null,
    ControlNameID: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Nodes: null,
    TextColor: null,
    TextFontString: null,
    TextHeight: null,
    SelectedNode: null,
    SelectedNodeTextColor: null,
    SelectedNodeTextFontString: null,
    SelectedNodeTextHeight: null,
    ExpandedNodeImgURL: null,
    ExpandedNodeImgURLWidth: null,
    ExpandedNodeImgURLHeight: null,
    CollapsedNodeImgURL: null,
    CollapsedNodeImgURLWidth: null,
    CollapsedNodeImgURLHeight: null,
    ClickNodeFunction: null,
    Tag: null,

    Initialize: function () {
        return createTreeview(this.CanvasID, this.ControlNameID, this.X, this.Y, this.Width,
            this.Height, this.Nodes, this.TextColor, this.TextFontString, this.TextHeight,
            this.SelectedNode, this.SelectedNodeTextColor, this.SelectedNodeTextFontString,
            this.SelectedNodeTextHeight, this.ExpandedNodeImgURL, this.ExpandedNodeImgURLWidth,
            this.ExpandedNodeImgURLHeight, this.CollapsedNodeImgURL,
            this.CollapsedNodeImgURLWidth, this.CollapsedNodeImgURLHeight,
            this.ClickNodeFunction, this.Tag);
    }
};

TreeviewNode.prototype = {
    ParentNode: null,
    IconImgURL: null,
    IconImgWidth: null,
    IconImgHeight: null,
    Expanded: false,
    ChildNodes: null,
    Text: null,
    Tag: null
};

TreeviewProps.prototype = {
    Control: null,
    ControlNameID: null,
    VSControl: null,
    HSControl: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Nodes: null,
    TextColor: null,
    TextFontString: null,
    TextHeight: null,
    SelectedNode: null,
    SelectedNodeTextColor: null,
    SelectedNodeTextFontString: null,
    SelectedNodeTextHeight: null,
    ExpandedNodeImgURL: null,
    CollapsedNodeImgURL: null,
    ClickNodeFunction: null,
    Tag: null,
    NodeCount: null,
    LevelOffset: null,
    ClickExtents: null,
    VisibleNodeCount: null
};

ClickExtent.prototype = {
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Node: null,
    Type: null //1 - Node, 2 - Expand Button, 3 - Icon Image
};

function getTreeViewProps(control) {
    for (var i = 0; i < treeViewPropsArray.length; i++) {
        if (treeViewPropsArray[i].Control === control) {
            return treeViewPropsArray[i];
        }
    }
}

function getVisibleNodeCount(control, nodes) {
    var treeViewProps = getTreeViewProps(control);
    for (var i = 0; i < nodes.length; i++) {
        treeViewProps.VisibleNodeCount++;
        if (nodes[i].Expanded && nodes[i].ChildNodes &&
            nodes[i].ChildNodes.length > 0) {
            treeViewProps.VisibleNodeCount +=
                getVisibleNodeCount(control, nodes[i].ChildNodes);
        }
    }
    return treeViewProps.VisibleNodeCount;
}

function getImgURLFromNodes(control, nodes) {
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].IconImgURL) {
            registerIconImage(control, nodes[i].IconImgURL);
        }
        for (var j = 0; j < nodes[i].ChildNodes.length; j++) {
            getImgURLFromNodes(control, nodes[i].ChildNodes);
        }
    }
}

function createTreeview(canvasID, controlNameID, x, y, width, height,
    nodes, textColor, textFontString, textHeight, selectedNode,
    selectedNodeTextColor, selectedNodeTextFontString,
    selectedNodeTextHeight, expandedNodeImgURL, expandedNodeImgURLWidth,
    expandedNodeImgURLHeigth, collapsedNodeImgURL, collapsedNodeImgURLWidth,
    collapsedNodeImgURLHeight, clickNodeFunction, tag) {
    var control = createControl(canvasID, x, y, width, height,
        'TreeView', controlNameID);
    var vsControl = createScrollBar(canvasID, controlNameID + 'VS',
        x + width, y, height, 1, true, control);
    var hsControl = createScrollBar(canvasID, controlNameID + 'HS',
        x, y + height, width, 1, false, control);
    registerIconImage(control, expandedNodeImgURL);
    registerIconImage(control, collapsedNodeImgURL);
    getImgURLFromNodes(control, nodes);
    var treeviewProps = new TreeviewProps();
    treeviewProps.Control = control;
    treeviewProps.ControlNameID = controlNameID;
    treeviewProps.VSControl = vsControl;
    treeviewProps.HSControl = hsControl;
    treeviewProps.X = x;
    treeviewProps.Y = y;
    treeviewProps.Width = width;
    treeviewProps.Height = height;
    treeviewProps.Nodes = nodes;
    treeviewProps.TextColor = textColor;
    treeviewProps.TextFontString = textFontString;
    treeviewProps.TextHeight = textHeight;
    treeviewProps.SelectedNode = selectedNode;
    treeviewProps.SelectedNodeTextColor = selectedNodeTextColor;
    treeviewProps.SelectedNodeTextFontString = selectedNodeTextFontString;
    treeviewProps.SelectedNodeTextHeight = selectedNodeTextHeight;
    treeviewProps.ExpandedNodeImgURL = expandedNodeImgURL;
    treeviewProps.ExpandedNodeImgURLWidth = expandedNodeImgURLWidth;
    treeviewProps.ExpandedNodeImgURLHeight = expandedNodeImgURLHeigth;
    treeviewProps.CollapsedNodeImgURL = collapsedNodeImgURL;
    treeviewProps.CollapsedNodeImgURLWidth = collapsedNodeImgURLWidth;
    treeviewProps.CollapsedNodeImgURLHeight = collapsedNodeImgURLHeight;
    treeviewProps.ClickNodeFunction = clickNodeFunction;
    treeviewProps.Tag = tag;
    treeviewProps.NodeCount = 0;
    treeviewProps.LevelOffset = 0;
    treeviewProps.ClickExtents = new Array();
    treeviewProps.VisibleNodeCount = 0;
    treeViewPropsArray.push(treeviewProps);
    var shownItemsCount = getVisibleNodeCount(control, nodes);
    var vsProps = getScrollBarProps(vsControl);
    vsProps.MaxItems = shownItemsCount > 0 ? shownItemsCount : 1;
    control.DrawFunction = drawTreeView;
    control.ClickFunction = clickTreeView;
    return control;
}

function drawTreeView(control) {
    var treeViewProps = getTreeViewProps(control);
    getImgURLFromNodes(control, treeViewProps.Nodes);
    var ctx = getCtx(control);
    ctx.save();
    ctx.fillStyle = '#FFFFFF';
    ctx.fillRect(treeViewProps.X, treeViewProps.Y, treeViewProps.Width, treeViewProps.Height);
    ctx.strokeStyle = '#C0C0C0';
    ctx.beginPath();
    ctx.rect(treeViewProps.X, treeViewProps.Y, treeViewProps.Width, treeViewProps.Height);
    ctx.stroke();
    ctx.beginPath();
    ctx.rect(treeViewProps.X, treeViewProps.Y, treeViewProps.Width, treeViewProps.Height);
    ctx.clip();
    var vsProps = getScrollBarProps(treeViewProps.VSControl);
    treeViewProps.VisibleNodeCount = 0;
    vsProps.MaxItems = getVisibleNodeCount(control, treeViewProps.Nodes);
    var selectedID = vsProps.SelectedID;
    treeViewProps.NodeCount = 0;
    treeViewProps.ClickExtents = new Array();
    drawNodes(ctx, treeViewProps, selectedID, treeViewProps.Nodes);
    ctx.restore();
}

function drawNodes(ctx, treeViewProps, selectedID, nodes) {
    for (var i = 0; i < nodes.length; i++) {
        treeViewProps.NodeCount++;
        if (treeViewProps.NodeCount >= selectedID) {
            drawNode(ctx, treeViewProps, nodes[i], selectedID);
        }
        if (nodes[i].Expanded && nodes[i].ChildNodes &&
            nodes[i].ChildNodes.length > 0) {
            drawNodes(ctx, treeViewProps, selectedID, nodes[i].ChildNodes);
        }
    }
}

function getNodeLevel(treeViewProps, node) {
    if (node.ParentNode) {
        treeViewProps.LevelOffset++;
        getNodeLevel(treeViewProps, node.ParentNode);
    }
}

function drawNode(ctx, treeViewProps, node, selectedID) {
    treeViewProps.LevelOffset = 0;
    getNodeLevel(treeViewProps, node);
    var xNodeOffset = treeViewProps.X + treeViewProps.LevelOffset * 23 + 5;
    var yNodeOffset = treeViewProps.Y + (treeViewProps.NodeCount - selectedID) *
        (treeViewProps.TextHeight + 10);
    var xNodeOffsetChanged = false;
    if (yNodeOffset <= treeViewProps.Y + treeViewProps.Height) {
        if (node.Expanded && node.ChildNodes.length > 0 &&
            treeViewProps.ExpandedNodeImgURL) {
            var expandedImg = getIconImage(treeViewProps.Control,
                treeViewProps.ExpandedNodeImgURL);
            if (expandedImg && expandedImg.ImgLoaded) {
                ctx.drawImage(expandedImg.Img, xNodeOffset, yNodeOffset,
                    treeViewProps.ExpandedNodeImgURLWidth,
                    treeViewProps.ExpandedNodeImgURLHeight);
                var ce = new ClickExtent();
                ce.X = xNodeOffset;
                ce.Y = yNodeOffset;
                ce.Width = treeViewProps.ExpandedNodeImgURLWidth;
                ce.Height = treeViewProps.ExpandedNodeImgURLHeight;
                ce.Node = node;
                ce.Type = 2;
                treeViewProps.ClickExtents.push(ce);
                xNodeOffset += treeViewProps.ExpandedNodeImgURLWidth + 5;
                xNodeOffsetChanged = true;
            }
        } else if (node.ChildNodes.length > 0 && treeViewProps.CollapsedNodeImgURL) {
            var collapsedImg = getIconImage(treeViewProps.Control,
                treeViewProps.CollapsedNodeImgURL);
            if (collapsedImg && collapsedImg.ImgLoaded) {
                ctx.drawImage(collapsedImg.Img, xNodeOffset, yNodeOffset,
                    treeViewProps.CollapsedNodeImgURLWidth,
                    treeViewProps.CollapsedNodeImgURLWidth);
                var ce2 = new ClickExtent();
                ce2.X = xNodeOffset;
                ce2.Y = yNodeOffset;
                ce2.Width = treeViewProps.CollapsedNodeImgURLWidth;
                ce2.Height = treeViewProps.CollapsedNodeImgURLWidth;
                ce2.Node = node;
                ce2.Type = 2;
                treeViewProps.ClickExtents.push(ce2);
                xNodeOffset += treeViewProps.CollapsedNodeImgURLWidth + 5;
                xNodeOffsetChanged = true;
            }
        }
        if (!xNodeOffsetChanged) {
            xNodeOffset += 23;
        }
        if (node.IconImgURL) {
            var img = getIconImage(treeViewProps.Control,
                node.IconImgURL);
            if (img && img.ImgLoaded) {
                ctx.drawImage(img.Img, xNodeOffset, yNodeOffset, node.IconImgWidth,
                    node.IconImgHeight);
                var ce3 = new ClickExtent();
                ce3.X = xNodeOffset;
                ce3.Y = yNodeOffset;
                ce3.Width = node.IconImgWidth;
                ce3.Height = node.IconImgHeight;
                ce3.Node = node;
                ce3.Type = 3;
                treeViewProps.ClickExtents.push(ce3);
                xNodeOffset += node.IconImgWidth + 5;
            }
        }
        if (node.Text) {
            ctx.fillStyle = treeViewProps.TextColor;
            ctx.font = treeViewProps.TextFontString;
            ctx.fillText(node.Text, xNodeOffset, yNodeOffset + treeViewProps.TextHeight + 3);
            var ce4 = new ClickExtent();
            ce4.X = xNodeOffset;
            ce4.Y = yNodeOffset;
            ce4.Width = ctx.measureText(node.Text).width;
            ce4.Height = treeViewProps.TextHeight;
            ce4.Node = node;
            ce4.Type = 1;
            treeViewProps.ClickExtents.push(ce4);
        }
    }
}

function clickTreeView(control, e) {
    var treeViewProps = getTreeViewProps(control);
    var x = e.X;
    var y = e.Y;
    for (var i = 0; i < treeViewProps.ClickExtents.length; i++) {
        if (x >= treeViewProps.ClickExtents[i].X &&
            x <= treeViewProps.ClickExtents[i].X + treeViewProps.ClickExtents[i].Width &&
            y >= treeViewProps.ClickExtents[i].Y &&
            y <= treeViewProps.ClickExtents[i].Y + treeViewProps.ClickExtents[i].Height) {
            if (treeViewProps.ClickExtents[i].Type === 2) {
                if (treeViewProps.ClickExtents[i].Node.Expanded) {
                    treeViewProps.ClickExtents[i].Node.Expanded = false;
                } else {
                    treeViewProps.ClickExtents[i].Node.Expanded = true;
                }
                if (typeof treeViewProps.ClickNodeFunction === 'function') {
                    treeViewProps.ClickNodeFunction(control, { X: x, Y: y },
                        treeViewProps.ClickExtents[i].Node,
                        treeViewProps.ClickExtents[i].Type);
                }
                control.XCanvas.InvalidateRect(control.CanvasID, treeViewProps.X,
                    treeViewProps.Y, treeViewProps.Width, treeViewProps.Height);
            } else if ((treeViewProps.ClickExtents[i].Type === 1 ||
                treeViewProps.ClickExtents[i].Type === 3) &&
                typeof treeViewProps.ClickNodeFunction === 'function') {
                treeViewProps.ClickNodeFunction(control, { X: x, Y: y },
                    treeViewProps.ClickExtents[i].Node, treeViewProps.ClickExtents[i].Type);
            }
        }
    }
}
