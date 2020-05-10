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

var gridPropsArray = new Array();

var Grid = function () { };
var GridProps = function () { };
var Column = function () { };
var ClickExtent = function () { };
var Cell = function () { };

Grid.prototype = {
    CanvasID: null,
    ControlNameID: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Depth: null,
    Rows: null,
    Columns: null,
    TextColor: null,
    TextFontString: null,
    TextHeight: null,
    CellHeight: null,
    CellBackgroundColor: null,
    HasHeader: null,
    HeaderTextColor: null,
    HeaderTextFontString: null,
    HeaderTextHeight: null,
    HeaderBackgroundColor: null,
    BorderColor: null,
    BorderLineWidth: null,
    SelectedCellBackgroundColor: null,
    NullCellBackgroundColor: null,
    HeaderClickFunction: null,
    cellClickFunction: null,
    TabStopIndex: null,
    Tag: null,

    Initialize: function () {
        return createGrid(this.CanvasID, this.ControlNameID, this.X, this.Y, this.Width,
            this.Height, this.Depth, this.Rows, this.Columns, this.TextColor,
            this.TextFontString, this.TextHeight, this.CellHeight,
            this.CellBackgroundColor, this.BorderColor, this.BorderLineWidth,
            this.HasHeader, this.HeaderTextColor, this.HeaderTextFontString,
            this.HeaderTextHeight, this.HeaderBackgroundColor,
            this.SelectedCellBackgroundColor, this.NullCellBackgroundColor,
            this.HeaderClickFunction, this.CellClickFunction, this.TabStopIndex, this.Tag);
    }
};

GridProps.prototype = {
    Control: null,
    ControlNameID: null,
    VSControl: null,
    HSControl: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Depth: null,
    Rows: null,
    Columns: null,
    TextColor: null,
    TextFontString: null,
    TextHeight: null,
    CellHeight: null,
    CellBackgroundColor: null,
    BorderColor: null,
    BorderLineWidth: null,
    HasHeader: null,
    HeaderTextColor: null,
    HeaderTextFontString: null,
    HeaderTextHeight: null,
    HeaderBackgroundColor: null,
    SelectedCellBackgroundColor: null,
    NullCellBackgroundColor: null,
    HeaderClickFunction: null,
    CellClickFunction: null,
    TabStopIndex: null,
    Tag: null,
    RowCount: null,
    HeaderClickExtents: null,
    CellClickExtents: null
};

Column.prototype = {
    Name: null,
    Width: null,
    SortOrder: null, //null - unsorted, 1 - ascending, 2 - descending
    Tag: null
};

Cell.prototype = {
    Name: null,
    Tag: null
};

ClickExtent.prototype = {
    X: null,
    Y: null,
    Width: null,
    Height: null,
    IsColumnHeaderCell: null,
    RowIndex: null,
    ColumnIndex: null
};

function getGridProps(control) {
    for (var i = 0; i < gridPropsArray.length; i++) {
        if (gridPropsArray[i].Control === control) {
            return gridPropsArray[i];
        }
    }
}

function createGrid(canvasID, controlNameID, x, y, width, height,
    depth, rows, columns, textColor, textFontString, textHeight,
    cellHeight, cellBackgroundColor, borderColor, borderLineWidth,
    hasHeader, headerTextColor, headerTextFontString, headerTextHeight,
    headerBackgroundColor, selectedCellBackgroundColor,
    nullCellBackgroundColor, headerClickFunction, cellClickFunction, tabStopIndex,
    tag) {
    var control = createControl(canvasID, x, y, width, height, depth, null,
        'Grid', controlNameID, null, tabStopIndex);
    var vsControl = createScrollBar(canvasID, controlNameID + 'VS',
        x + width, y, height, 1, true);
    var vsScrollBarProps = getScrollBarProps(vsControl);
    vsScrollBarProps.ParentControl = control;
    var hsControl = createScrollBar(canvasID, controlNameID + 'HS',
        x, y + height, width, 1, false);
    var hsScrollBarProps = getScrollBarProps(hsControl);
    hsScrollBarProps.ParentControl = control;
    var gridProps = new GridProps();
    gridProps.Control = control;
    gridProps.ControlNameID = controlNameID;
    gridProps.VSControl = vsControl;
    gridProps.HSControl = hsControl;
    gridProps.X = x;
    gridProps.Y = y;
    gridProps.Width = width;
    gridProps.Height = height;
    gridProps.Depth = depth;
    gridProps.Rows = rows;
    gridProps.Columns = columns;
    gridProps.TextColor = textColor;
    gridProps.TextFontString = textFontString;
    gridProps.TextHeight = textHeight;
    gridProps.CellHeight = cellHeight;
    gridProps.CellBackgroundColor = cellBackgroundColor;
    gridProps.HasHeader = hasHeader;
    gridProps.HeaderTextColor = headerTextColor;
    gridProps.HeaderTextFontString = headerTextFontString;
    gridProps.HeaderTextHeight = headerTextHeight;
    gridProps.HeaderBackgroundColor = headerBackgroundColor;
    gridProps.BorderColor = borderColor;
    gridProps.BorderLineWidth = borderLineWidth;
    gridProps.SelectedCellBackgroundColor = selectedCellBackgroundColor;
    gridProps.NullCellBackgroundColor = nullCellBackgroundColor;
    gridProps.HeaderClickFunction = headerClickFunction;
    gridProps.CellClickFunction = cellClickFunction;
    gridProps.TabStopIndex = tabStopIndex;
    gridProps.Tag = tag;
    gridProps.RowCount = 0;
    gridProps.HeaderClickExtents = new Array();
    gridProps.CellClickExtents = new Array();
    gridPropsArray.push(gridProps);
    var shownItemsCount = rows.length + 1;
    var vsProps = getScrollBarProps(vsControl);
    vsProps.MaxItems = shownItemsCount > 0 ? shownItemsCount : 1;
    control.DrawFunction = drawGrid;
    control.ClickFunction = clickGrid;
    return control;
}

function drawGrid(control) {
    var gridProps = getGridProps(control);
    var ctx = getCtx(control);
    ctx.save();
    ctx.fillStyle = '#FFFFFF';
    ctx.fillRect(gridProps.X, gridProps.Y, gridProps.Width, gridProps.Height);
    ctx.strokeStyle = gridProps.BorderColor;
    ctx.lineWidth = gridProps.BorderLineWidth;
    ctx.beginPath();
    ctx.rect(gridProps.X, gridProps.Y, gridProps.Width, gridProps.Height);
    ctx.stroke();
    ctx.restore();
    var vsProps = getScrollBarProps(gridProps.VSControl);
    vsProps.MaxItems = gridProps.Rows.length + 1;
    var selectedID = vsProps.SelectedID;
    gridProps.HeaderClickExtents = new Array();
    gridProps.CellClickExtents = new Array();
    var xOffset = 0;
    var yOffset = 0;
    if (gridProps.HasHeader) {
        for (var c = 0; c < gridProps.Columns.length && xOffset <
            gridProps.Width; c++) {
            ctx.save();
            ctx.fillStyle = gridProps.HeaderBackgroundColor;
            ctx.fillRect(gridProps.X + xOffset, gridProps.Y,
                xOffset + gridProps.Columns[c].Width > gridProps.Width ?
                    gridProps.Width - xOffset : gridProps.Columns[c].Width,
                gridProps.CellHeight);
            ctx.strokeStyle = gridProps.BorderColor;
            ctx.lineWidth = gridProps.BorderLineWidth;
            ctx.beginPath();
            ctx.rect(gridProps.X + xOffset, gridProps.Y,
                xOffset + gridProps.Columns[c].Width > gridProps.Width ?
                    gridProps.Width - xOffset : gridProps.Columns[c].Width,
                gridProps.CellHeight);
            ctx.stroke();
            ctx.beginPath();
            ctx.rect(gridProps.X + xOffset, gridProps.Y,
                xOffset + gridProps.Columns[c].Width > gridProps.Width ?
                    gridProps.Width - xOffset : gridProps.Columns[c].Width,
                gridProps.CellHeight);
            ctx.clip();
            ctx.fillStyle = gridProps.HeaderTextColor;
            ctx.font = gridProps.HeaderTextFontString;
            ctx.fillText(gridProps.Columns[c].Name, gridProps.X + xOffset,
                gridProps.Y + gridProps.TextHeight +
                (gridProps.CellHeight - gridProps.TextHeight) / 2);
            var clickExtent = new ClickExtent();
            clickExtent.X = gridProps.X + xOffset;
            clickExtent.Y = gridProps.Y;
            clickExtent.Width = gridProps.Columns[c].Width;
            clickExtent.Height = gridProps.CellHeight;
            clickExtent.IsColumnHeaderCell = true;
            clickExtent.ColumnIndex = c;
            gridProps.HeaderClickExtents.push(clickExtent);
            xOffset += gridProps.Columns[c].Width;
            ctx.restore();
        }
        yOffset = gridProps.CellHeight;
    }
    for (var i = 0; i < gridProps.Rows.length && yOffset < gridProps.Y +
        gridProps.Height; i++) {
        xOffset = 0;
        if (i >= selectedID && yOffset <= gridProps.Y + gridProps.Height) {
            for (var j = 0; j < gridProps.Rows[i].length && xOffset <
                gridProps.X + gridProps.Width; j++) {
                ctx.save();
                ctx.fillStyle = gridProps.CellBackgroundColor;
                ctx.fillRect(gridProps.X + xOffset, gridProps.Y + yOffset,
                    xOffset + gridProps.Columns[j].Width > gridProps.X + gridProps.Width ?
                        gridProps.Width - xOffset : gridProps.Columns[j].Width,
                    yOffset + gridProps.CellHeight > gridProps.Y + gridProps.Height ?
                        gridProps.Height - yOffset : gridProps.CellHeight);
                ctx.strokeStyle = gridProps.BorderColor;
                ctx.lineWidth = gridProps.BorderLineWidth;
                ctx.beginPath();
                ctx.rect(gridProps.X + xOffset, gridProps.Y + yOffset,
                    xOffset + gridProps.Columns[j].Width > gridProps.X + gridProps.Width ?
                        gridProps.Width - xOffset : gridProps.Columns[j].Width,
                    yOffset + gridProps.CellHeight > gridProps.Y + gridProps.Height ?
                        gridProps.Height - yOffset : gridProps.CellHeight);
                ctx.stroke();
                ctx.beginPath();
                ctx.rect(gridProps.X + xOffset, gridProps.Y + yOffset,
                    xOffset + gridProps.Columns[j].Width > gridProps.X + gridProps.Width ?
                        gridProps.Width - xOffset : gridProps.Columns[j].Width,
                    yOffset + gridProps.CellHeight > gridProps.Y + gridProps.Height ?
                        gridProps.Height - yOffset : gridProps.CellHeight);
                ctx.clip();
                ctx.fillStyle = gridProps.TextColor;
                ctx.font = gridProps.TextFontString;
                ctx.fillText(gridProps.Rows[i][j].Name, gridProps.X + xOffset,
                    gridProps.Y + gridProps.TextHeight +
                    (gridProps.CellHeight - gridProps.TextHeight) / 2 + yOffset);
                var clickExtent2 = new ClickExtent();
                clickExtent2.X = gridProps.X + xOffset;
                clickExtent2.Y = gridProps.Y + yOffset;
                clickExtent2.Width = gridProps.Columns[j].Width;
                clickExtent2.Height = gridProps.CellHeight;
                clickExtent2.IsColumnHeaderCell = false;
                clickExtent2.RowIndex = i;
                clickExtent2.ColumnIndex = j;
                gridProps.CellClickExtents.push(clickExtent2);
                xOffset += gridProps.Columns[j].Width;
                ctx.restore();
            }
            yOffset += gridProps.CellHeight;
        }
    }
}

function clickGrid(control, e) {
    var gridProps = getGridProps(control);
    var x = e.X;
    var y = e.Y;
    if (gridProps.HasHeader) {
        for (var i = 0; i < gridProps.HeaderClickExtents.length; i++) {
            if (x >= gridProps.HeaderClickExtents[i].X &&
                x <= gridProps.HeaderClickExtents[i].X +
                gridProps.HeaderClickExtents[i].Width &&
                y >= gridProps.HeaderClickExtents[i].Y &&
                y <= gridProps.HeaderClickExtents[i].Y +
                gridProps.HeaderClickExtents[i].Height) {
                if (typeof gridProps.HeaderClickFunction === 'function') {
                    gridProps.HeaderClickFunction(control, e,
                        gridProps.HeaderClickExtents[i]);
                    return;
                }
            }
        }
    }
    for (var j = 0; j < gridProps.CellClickExtents.length; j++) {
        if (x >= gridProps.CellClickExtents[j].X &&
            x <= gridProps.CellClickExtents[j].X +
            gridProps.CellClickExtents[j].Width &&
            y >= gridProps.CellClickExtents[j].Y &&
            y <= gridProps.CellClickExtents[j].Y +
            gridProps.CellClickExtents[j].Height) {
            if (typeof gridProps.CellClickFunction === 'function') {
                gridProps.CellClickFunction(control, e,
                    gridProps.CellClickExtents[j]);
                return;
            }
        }
    }
}
