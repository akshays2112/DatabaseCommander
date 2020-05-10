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

//Code for Scrollbar e8e8ec c2c3c9  868999

var ScrollBar = function () { };
var ScrollBarProps = function () { };
var ClickExtent = function () { };

ScrollBar.prototype = {
    CanvasID: null,
    ControlNameID: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    MaxItems: null,
    IsVertical: null,
    DrawFunction: null,
    ClickFunction: null,
    ParentControl: null
};

ScrollBarProps.prototype = {
    Control: null,
    ControlNameID: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    MaxItems: null,
    IsVertical: null,
    SelectedID: null,
    ClickExtents: null,
    ParentControl: null
};

ClickExtent.prototype = {
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Type: null // 1 - up arrow, 2 - thumb, 3 - down arrow
};

var scrollBarPropsArray = new Array();

function getScrollBarProps(control) {
    for (var i = 0; i < scrollBarPropsArray.length; i++) {
        if (scrollBarPropsArray[i].Control === control) {
            return scrollBarPropsArray[i];
        }
    }
}

function drawScrollBar(control) {
    var scrollBarProps = getScrollBarProps(control);
    var ctx = getCtx(control);
    ctx.fillStyle = '#FFFFFF';
    ctx.fillRect(scrollBarProps.X, scrollBarProps.Y, scrollBarProps.Width,
        scrollBarProps.Height);
    scrollBarProps.ClickExtents = new Array();
    if (scrollBarProps.IsVertical) {
        ctx.fillStyle = '#e8e8ec';
        ctx.fillRect(scrollBarProps.X, scrollBarProps.Y, 23, scrollBarProps.Height);
        ctx.fillStyle = '#c2c3c9';
        ctx.beginPath();
        ctx.moveTo(scrollBarProps.X + 12, scrollBarProps.Y + 5);
        ctx.lineTo(scrollBarProps.X + 5, scrollBarProps.Y + 18);
        ctx.lineTo(scrollBarProps.X + 18, scrollBarProps.Y + 18);
        ctx.closePath();
        ctx.fill();
        var upArrow = new ClickExtent();
        upArrow.X = scrollBarProps.X + 5;
        upArrow.Y = scrollBarProps.Y + 5;
        upArrow.Width = 13;
        upArrow.Height = 13;
        upArrow.Type = 1;
        scrollBarProps.ClickExtents.push(upArrow);
        ctx.fillStyle = '#868999';
        ctx.fillRect(scrollBarProps.X + 5, scrollBarProps.Y + 21 + (scrollBarProps.Height
            - 84) * scrollBarProps.SelectedID / scrollBarProps.MaxItems, 13, 42);
        var thumb = new ClickExtent();
        thumb.X = scrollBarProps.X + 5;
        thumb.Y = scrollBarProps.Y + 21 + scrollBarProps.Height *
            scrollBarProps.SelectedID / scrollBarProps.MaxItems;
        thumb.Width = 13;
        thumb.Height = 42;
        thumb.Type = 2;
        scrollBarProps.ClickExtents.push(thumb);
        ctx.fillStyle = '#c2c3c9';
        ctx.beginPath();
        ctx.moveTo(scrollBarProps.X + 5, scrollBarProps.Y + scrollBarProps.Height - 18);
        ctx.lineTo(scrollBarProps.X + 18, scrollBarProps.Y + scrollBarProps.Height - 18);
        ctx.lineTo(scrollBarProps.X + 12, scrollBarProps.Y + scrollBarProps.Height - 5);
        ctx.closePath();
        ctx.fill();
        var downArrow = new ClickExtent();
        downArrow.X = scrollBarProps.X + 5;
        downArrow.Y = scrollBarProps.Y + scrollBarProps.Height - 18;
        downArrow.Width = 13;
        downArrow.Height = 13;
        downArrow.Type = 3;
        scrollBarProps.ClickExtents.push(downArrow);
    }
}

function scrollBarClick(control, e) {
    var scrollBarProps = getScrollBarProps(control);
    for (var i = 0; i < scrollBarProps.ClickExtents.length; i++) {
        if (e.X >= scrollBarProps.ClickExtents[i].X &&
            e.X <= scrollBarProps.ClickExtents[i].X + scrollBarProps.ClickExtents[i].Width &&
            e.Y >= scrollBarProps.ClickExtents[i].Y &&
            e.Y <= scrollBarProps.ClickExtents[i].Y + scrollBarProps.ClickExtents[i].Height) {
            if (scrollBarProps.ClickExtents[i].Type === 1) {
                scrollBarProps.SelectedID--;
                if (scrollBarProps.SelectedID < 0) {
                    scrollBarProps.SelectedID = 0;
                }
            } else if (scrollBarProps.ClickExtents[i].Type === 3) {
                scrollBarProps.SelectedID++;
                if (scrollBarProps.SelectedID > scrollBarProps.MaxItems - 1) {
                    scrollBarProps.SelectedID = scrollBarProps.MaxItems - 1;
                }
            }
            control.DrawFunction(control);
            scrollBarProps.ParentControl.DrawFunction(scrollBarProps.ParentControl);
        }
    }
}

function scrollBarMouseDown(control, e) {
}

function scrollBarMouseMove(control, e) {
}

function scrollBarMouseUp(control, e) {
}

function scrollBarLostFocus(control, e) {
}

function createScrollBar(canvasID, controlNameID, x, y, len, maxItems, isVertical, parentControl) {
    var control;
    if (isVertical) {
        control = createControl(canvasID, x, y, 23, len, 'ScrollBar', controlNameID);
    } else {
        control = createControl(canvasID, x, y, len, 23, 'ScrollBar', controlNameID);
    }
    var scrollBarProps = new ScrollBarProps();
    scrollBarProps.Control = control;
    scrollBarProps.ControlNameID = controlNameID;
    scrollBarProps.X = x;
    scrollBarProps.Y = y;
    if (isVertical) {
        scrollBarProps.Width = 23;
        scrollBarProps.Height = len;
    } else {
        scrollBarProps.Width = len;
        scrollBarProps.Height = 23;
    }
    scrollBarProps.IsVertical = isVertical;
    scrollBarProps.SelectedID = 0;
    scrollBarProps.MaxItems = maxItems;
    scrollBarProps.ClickExtents = new Array();
    scrollBarProps.ParentControl = parentControl;
    control.DrawFunction = drawScrollBar;
    control.ClickFunction = scrollBarClick;
    scrollBarPropsArray.push(scrollBarProps);
    return control;
}
