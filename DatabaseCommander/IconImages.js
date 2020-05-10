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

var iconImages = new Array();

var IconImage = function () { };

IconImage.prototype = {
    Control: null,
    ImgURL: null,
    Img: null,
    ImgLoaded: false
};

function registerIconImage(control, imgURL) {
    var foundImgURL = false;
    for (var i = 0; i < iconImages.length; i++) {
        if (iconImages[i].ImgURL === imgURL) {
            foundImgURL = true;
        }
    }
    if (!foundImgURL) {
        var img = new Image();
        var imgIcon = new IconImage();
        imgIcon.Control = control;
        imgIcon.ImgURL = imgURL;
        iconImages.push(imgIcon);
        img.onload = function () {
            imgIcon.Img = img;
            imgIcon.ImgLoaded = true;
            var treeViewProps = getTreeViewProps(control);
            control.XCanvas.InvalidateRect(control.CanvasID,
                treeViewProps.X, treeViewProps.Y, treeViewProps.Width,
                treeViewProps.Height);
        };
        img.src = imgURL;
    }
}

function getIconImage(control, imgURL) {
    for (var i = 0; i < iconImages.length; i++) {
        if (iconImages[i].Control === control && iconImages[i].ImgURL === imgURL) {
            return iconImages[i];
        }
    }
    return null;
}
