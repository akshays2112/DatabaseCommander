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

var xCanvases = new Array();

var XCanvas = function () { };
var Control = function () { };

XCanvas.prototype = {
    CanvasID: null,
    Canvas: null,
    Ctx: null,
    OnClickFunctions: null,
    OnDblClickFunctions: null,
    OnDragFunctions: null,
    OnDragEndFunctions: null,
    OnDragEnterFunctions: null,
    OnDragLeaveFunctions: null,
    OnDragOverFunctions: null,
    OnDragStartFunctions: null,
    OnDropFunctions: null,
    OnKeyPressFunctions: null,
    OnKeyDownFunctions: null,
    TouchStartFunctions: null,
    TouchMoveFunctions: null,
    TouchEndFunctions: null,
    OnMouseDownFunctions: null,
    OnMouseMoveFunctions: null,
    OnMouseUpFunctions: null,
    OnMouseOutFunctions: null,
    OnMouseOverFunctions: null,
    OnMouseWheelFunctions: null,
    OnScrollFunctions: null,
    OnContextMenuFunctions: null,
    Controls: null,
    CurrentWindowID: null,
    HighestDepth: null,
    CurrentTabStopIndex: null,
    InvalidateRect: null
};

Control.prototype = {
    CanvasID: null,
    XCanvas: null,
    X: null,
    Y: null,
    Width: null,
    Height: null,
    Depth: null,
    ParentWindowID: null,
    ControlTypeName: null,
    ControlNameID: null,
    TabStopIndex: null,
    DrawFunction: null,
    ClickFunction: null
};

function getXCanvas(canvasID) {
    for (var i = 0; i < xCanvases.length; i++) {
        if (xCanvases[i].CanvasID === canvasID) {
            return xCanvases[i];
        }
    }
}

function getCtx(control) {
    for (var c = 0; c < xCanvases.length; c++) {
        for (var i = 0; i < xCanvases[c].Controls.length; i++) {
            if (xCanvases[c].Controls[i] === control) {
                return xCanvases[c].Ctx;
            }
        }
    }
}

function getControl(canvasID, windowID) {
    for (var i = 0; i < controls.length; i++) {
        if (controls[i].CanvasID === canvasID && controls[i].WindowID === windowID) {
            return controls[i];
        }
    }
}

function createControl(canvasID, x, y, width, height, depth, controlTypeName,
    controlNameID) {
    var xCanvas = getXCanvas(canvasID);
    var control = new Control();
    control.XCanvas = xCanvas;
    control.X = x;
    control.Y = y;
    control.Width = width;
    control.Height = height;
    control.ControlTypeName = controlTypeName;
    control.ControlNameID = controlNameID;
    xCanvas.Controls.push(control);
    return control;
}

function registerCanvas(canvasID) {
    var xCanvas = new XCanvas();
    xCanvas.CanvasID = canvasID;
    xCanvas.Canvas = document.getElementById(canvasID);
    xCanvas.Ctx = xCanvas.Canvas.getContext('2d');
    xCanvas.OnClickFunctions = new Array();
    xCanvas.OnDblClickFunctions = new Array();
    xCanvas.OnDragFunctions = new Array();
    xCanvas.OnDragEndFunctions = new Array();
    xCanvas.OnDragEnterFunctions = new Array();
    xCanvas.OnDragLeaveFunctions = new Array();
    xCanvas.OnDragOverFunctions = new Array();
    xCanvas.OnDragStartFunctions = new Array();
    xCanvas.OnDropFunctions = new Array();
    xCanvas.OnKeyPressFunctions = new Array();
    xCanvas.OnKeyDownFunctions = new Array();
    xCanvas.TouchStartFunctions = new Array();
    xCanvas.TouchMoveFunctions = new Array();
    xCanvas.TouchEndFunctions = new Array();
    xCanvas.OnMouseDownFunctions = new Array();
    xCanvas.OnMouseMoveFunctions = new Array();
    xCanvas.OnMouseUpFunctions = new Array();
    xCanvas.OnMouseOutFunctions = new Array();
    xCanvas.OnMouseOverFunctions = new Array();
    xCanvas.OnMouseWheelFunctions = new Array();
    xCanvas.OnScrollFunctions = new Array();
    xCanvas.OnContextMenuFunctions = new Array();
    xCanvas.Controls = new Array();
    xCanvas.CurrentWindowID = 0;
    xCanvas.HighestDepth = 0;
    xCanvas.CurrentTabStopIndex = 0;
    xCanvases.push(xCanvas);
    xCanvas.InvalidateRect = function (canvasID, x, y, width, height) {
        for (var i = 0; i < xCanvas.Controls.length; i++) {
            if (x <= xCanvas.Controls[i].X + xCanvas.Controls[i].Width &&
                xCanvas.Controls[i].X <= x + width &&
                y <= xCanvas.Controls[i].Y + xCanvas.Controls[i].Height &&
                xCanvas.Controls[i].Y <= y + height) {
                if (typeof xCanvas.Controls[i].DrawFunction === 'function') {
                    xCanvas.Controls[i].DrawFunction(xCanvas.Controls[i]);
                }
            }
        }
    };
    xCanvas.Canvas.addEventListener('click', function (e) {
        var tmp = e.currentTarget.getBoundingClientRect();
        var x = e.pageX - tmp.left;
        var y = e.pageY - tmp.top;
        for (var i = 0; i < xCanvas.Controls.length; i++) {
            if (x > xCanvas.Controls[i].X && x < xCanvas.Controls[i].X +
                xCanvas.Controls[i].Width && y > xCanvas.Controls[i].Y &&
                xCanvas.Controls[i].Y + xCanvas.Controls[i].Height) {
                if (xCanvas.Controls[i].ClickFunction &&
                    typeof xCanvas.Controls[i].ClickFunction === 'function') {
                    xCanvas.Controls[i].ClickFunction(xCanvas.Controls[i], {X: x, Y: y});
                }
            }
        }
    });
    return xCanvas;
}

function invokeServerSide(url, responseFunction, parameter) {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            responseFunction(JSON.parse(this.responseText), parameter);
        }
    };
    xmlhttp.open("GET", url, true);
    xmlhttp.send();
}
