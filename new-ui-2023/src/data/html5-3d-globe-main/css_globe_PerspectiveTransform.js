/*
 *  Optimized version of PerspectiveTransform.js
 *  by Edan Kwan
 *  website: http://www.edankwan.com/
 *  twitter: https://twitter.com/#!/edankwan
 *  Lab: www.edankwan.com/lab
 *
 *  The original PerspectiveTransform.js is created by  Israel Pastrana
 *  http://www.is-real.net/experiments/css3/wonder-webkit/js/real/display/PerspectiveTransform.js
 *
 *  Matrix Libraries from a Java port of JAMA: A Java Matrix Package, http://math.nist.gov/javanumerics/jama/
 *  Developed by Dr Peter Coxhead: http://www.cs.bham.ac.uk/~pxc/
 *  Available here: http://www.cs.bham.ac.uk/~pxc/js/
 *
 *  I simply removed some irrelevant variables and functions and merge everything into a smaller function. I also added some error checking functions and bug fixing things.
 */
(function (define) {
    define(function(){

function PerspectiveTransform(element, width, height, useBackFacing){

    this.element = element;
    this.style = element.style;
    this.computedStyle = window.getComputedStyle(element);
    this.width = width;
    this.height = height;
    this.useBackFacing = !!useBackFacing;

    this.topLeft = {x: 0, y: 0};
    this.topRight = {x: width, y: 0};
    this.bottomLeft = {x: 0, y: height};
    this.bottomRight = {x: width, y: height};
    this.calcStyle = '';
}

PerspectiveTransform.useDPRFix = false;
PerspectiveTransform.dpr = 1;

PerspectiveTransform.prototype = (function(){

    var app = {
        stylePrefix: ''
    };

    var aM = [[0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 1, 0, 0]];
    var bM = [0, 0, 0, 0, 0, 0, 0, 0];

    function _setTransformStyleName(){
        var testStyle = document.createElement('div').style;
        app.stylePrefix =
            'webkitTransform' in testStyle ? 'webkit' :
            'MozTransform' in testStyle ? 'Moz' :
            'msTransform' in testStyle ? 'ms' :
            '';
        PerspectiveTransform.transformStyleName = app.stylePrefix + (app.stylePrefix.length>0?'Transform':'transform');
        PerspectiveTransform.transformDomStyleName = '-'+app.stylePrefix.toLowerCase()+'-transform';
        PerspectiveTransform.transformOriginStyleName = app.stylePrefix + (app.stylePrefix.length>0?'TransformOrigin':'transformOrigin');
        PerspectiveTransform.transformOriginDomStyleName = '-'+app.stylePrefix.toLowerCase()+'-transform-origin';
    }


    // Check the distances between each points and if there is some points with the distance lequal to or less than 1 pixel, then return true. Otherwise return false;
    function _hasDistancesError(){
        var lenX = this.topLeft.x - this.topRight.x;
        var lenY = this.topLeft.y - this.topRight.y;
        if(Math.sqrt(lenX * lenX +  lenY * lenY)<=1) return true;
        lenX = this.bottomLeft.x - this.bottomRight.x;
        lenY = this.bottomLeft.y - this.bottomRight.y;
        if(Math.sqrt(lenX * lenX +  lenY * lenY)<=1) return true;
        lenX = this.topLeft.x - this.bottomLeft.x;
        lenY = this.topLeft.y - this.bottomLeft.y;
        if(Math.sqrt(lenX * lenX +  lenY * lenY)<=1) return true;
        lenX = this.topRight.x - this.bottomRight.x;
        lenY = this.topRight.y - this.bottomRight.y;
        if( Math.sqrt(lenX * lenX +  lenY * lenY)<=1) return true;
        lenX = this.topLeft.x - this.bottomRight.x;
        lenY = this.topLeft.y - this.bottomRight.y;
        if( Math.sqrt(lenX * lenX +  lenY * lenY)<=1) return true;
        lenX = this.topRight.x - this.bottomLeft.x;
        lenY = this.topRight.y - this.bottomLeft.y;
        if( Math.sqrt(lenX * lenX +  lenY * lenY)<=1) return true;

        return false;
    }

    // Get the determinant of given 3 points
    function _getDeterminant(p0, p1, p2){
        return p0.x * p1.y + p1.x * p2.y + p2.x * p0.y - p0.y * p1.x - p1.y * p2.x - p2.y * p0.x;
    }

    // Return true if it is a concave polygon or if it is backfacing when the useBackFacing property is false. Otehrwise return true;
    function _hasPolyonError(){
        var det1 = _getDeterminant(this.topLeft, this.topRight, this.bottomRight);
        var det2 = _getDeterminant(this.bottomRight, this.bottomLeft, this.topLeft);
        if(this.useBackFacing){
            if(det1*det2<=0) return true;
        }else{
            if(det1<=0||det2<=0) return true;
        }
        var det1 = _getDeterminant(this.topRight, this.bottomRight, this.bottomLeft);
        var det2 = _getDeterminant(this.bottomLeft, this.topLeft, this.topRight);
        if(this.useBackFacing){
            if(det1*det2<=0) return true;
        }else{
            if(det1<=0||det2<=0) return true;
        }
        return false;
    }

    function checkError(){
        if(_hasDistancesError.apply(this)) return 1; // Points are too close to each other.
        if(_hasPolyonError.apply(this)) return 2; // Concave or backfacing if the useBackFacing property is false
        return 0; // no error
    }

    function calc() {
        var width = this.width;
        var height = this.height;

        //  get the offset from the transfrom origin of the element
        var offsetX = 0;
        var offsetY = 0;
        var offset = this.computedStyle.getPropertyValue(PerspectiveTransform.transformOriginDomStyleName);
        if(offset.indexOf('px')>-1){
            offset = offset.split('px');
            offsetX = -parseFloat(offset[0]);
            offsetY = -parseFloat(offset[1]);
        }else if(offset.indexOf('%')>-1){
            offset = offset.split('%');
            offsetX = -parseFloat(offset[0]) * width / 100;
            offsetY = -parseFloat(offset[1]) * height / 100;
        }

        //  magic here:
        var dst = [this.topLeft, this.topRight, this.bottomLeft, this.bottomRight];
        var arr = [0, 1, 2, 3, 4, 5, 6, 7];
        for(var i = 0; i < 4; i++) {
            aM[i][0] = aM[i+4][3] = i & 1 ? width + offsetX : offsetX;
            aM[i][1] = aM[i+4][4] = (i > 1 ? height + offsetY : offsetY);
            aM[i][6] = (i & 1 ? -offsetX-width : -offsetX) * (dst[i].x + offsetX);
            aM[i][7] = (i > 1 ? -offsetY-height : -offsetY) * (dst[i].x + offsetX);
            aM[i+4][6] = (i & 1 ? -offsetX-width : -offsetX) * (dst[i].y + offsetY);
            aM[i+4][7] = (i > 1 ? -offsetY-height : -offsetY) * (dst[i].y + offsetY);
            bM[i] = (dst[i].x + offsetX);
            bM[i + 4] = (dst[i].y + offsetY);
            aM[i][2] = aM[i+4][5] = 1;
            aM[i][3] = aM[i][4] = aM[i][5] = aM[i+4][0] = aM[i+4][1] = aM[i+4][2] = 0;
        }
        var kmax, sum;
        var row;
        var col = [];
        var i, j, k, tmp;
        for(var j = 0; j < 8; j++) {
            for(var i = 0; i < 8; i++)  col[i] = aM[i][j];
            for(i = 0; i < 8; i++) {
                row = aM[i];
                kmax = i<j?i:j;
                sum = 0.0;
                for(var k = 0; k < kmax; k++) sum += row[k] * col[k];
                row[j] = col[i] -= sum;
            }
            var p = j;
            for(i = j + 1; i < 8; i++) {
                if(Math.abs(col[i]) > Math.abs(col[p])) p = i;
            }
            if(p != j) {
                for(k = 0; k < 8; k++) {
                    tmp = aM[p][k];
                    aM[p][k] = aM[j][k];
                    aM[j][k] = tmp;
                }
                tmp = arr[p];
                arr[p] = arr[j];
                arr[j] = tmp;
            }
            if(aM[j][j] != 0.0) for(i = j + 1; i < 8; i++) aM[i][j] /= aM[j][j];
        }
        for(i = 0; i < 8; i++) arr[i] = bM[arr[i]];
        for(k = 0; k < 8; k++) {
            for(i = k + 1; i < 8; i++) arr[i] -= arr[k] * aM[i][k];
        }
        for(k = 7; k > -1; k--) {
            arr[k] /= aM[k][k];
            for(i = 0; i < k; i++) arr[i] -= arr[k] * aM[i][k];
        }

         return this.calcStyle = 'matrix3d(' + arr[0].toFixed(9) + ',' + arr[3].toFixed(9) + ', 0,' + arr[6].toFixed(9) + ',' + arr[1].toFixed(9) + ',' + arr[4].toFixed(9) + ', 0,' + arr[7].toFixed(9) + ',0, 0, 1, 0,' + arr[2].toFixed(9) + ',' + arr[5].toFixed(9) + ', 0, 1)';

    }

    function update(style) {

        style = style || this.calcStyle;

        if(PerspectiveTransform.useDPRFix) {
            var dpr = PerspectiveTransform.dpr;
            style = 'scale(' + dpr + ',' + dpr + ')perspective(1000px)' + style + 'translateZ('+ ((1 - dpr) * 1000) + 'px)';
        }

        // use toFixed() just in case the Number became something like 3.10000001234e-9
        return this.style[PerspectiveTransform.transformStyleName] = style;
    }

    _setTransformStyleName();

    app.calc = calc;
    app.update = update;
    app.checkError = checkError;

    return app;


})();


        return PerspectiveTransform;
    });
}(typeof define === "function" && define.amd ? define : function (app) {
    window["PerspectiveTransform"] = app();
}));
