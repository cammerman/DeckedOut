// The content of this file was taken from the blog post at http://windyroad.org/2007/05/18/resolution-independent-web-design/
// via the download http://windyroad.org/wordpress/wp-content/uploads/2007/06/resolution-independence.zip

// Copyright (C)2007 Windy Road
// This work is licensed under a Creative Commons Attribution 2.5 License.  See http://creativecommons.org/licenses/by/2.5/au/

window.onload = function () {
    fitToScreen();
}

var timeout = null;

window.onresize = function () {
    clearTimeout(timeout);
    timeout = setTimeout(fitToScreen, 10);
};

function windowWidth() {
    return document.getElementById('page-width').offsetWidth;
}


function textWidth() {
    return document.getElementById('content').offsetWidth;
}

function displayDims() {
    targetWidth = windowWidth();
    mainW = document.getElementById('content').offsetWidth;
    deltaW2 = (deltaW / 100) * (mainW / targetWidth) * 100;
    document.getElementById('debug').innerHTML =
		"mainW " + mainW + " : targetW " + targetWidth + "<br/>"
		+ "deltaW " + deltaW + "<br/>"
		+ "deltaW2 " + deltaW2 + "<br/>"
		+ "currentW " + currentWidth + "<br/>";

}

var currentWidth = 0;
function fitToScreen() {
    if (windowWidth() != currentWidth) {
        resetLayout();
        targetWidth = windowWidth();
        mainW = document.getElementById('content').offsetWidth;
        deltaW = targetWidth / mainW * 100;
        setFontSize(deltaW);
        setImageSize(deltaW);
        currentWidth = windowWidth();
        newMainW = document.getElementById('content').offsetWidth;
        displayDims();
        if (mainW > currentWidth) {
            deltaW2 = (deltaW / 100) * (mainW / targetWidth) * 100;
            setFontSize(deltaW2);
            setImageSize(deltaW2);
            document.getElementById('header').style.width = mainW + "px";
            document.getElementById('footer').style.width = mainW + "px";
            currentWidth = windowWidth();
        }
    }
}

function setFontSize(size) {
    document.body.style.fontSize = size + '%';
}

function setImageSize(size) {
//    image = document.getElementById('trees');
//    imageW = Math.floor(320 * size / 100);
//    image.src = "resources/scaleimage.php?image=wallpaper1.jpg&width=" + imageW;
//    image.style.width = imageW + "px";

//    image = document.getElementById('cc');
//    imageW = Math.floor(80 * size / 100);
//    image.src = "resources/scaleimage.php?image=cc-lic.png&width=" + imageW;
//    image.style.width = imageW + "px";

//    image = document.getElementById('logo');
//    imageW = Math.floor(100 * size / 100);
//    image.src = "resources/scaleimage.php?image=windyroadx4.png&width=" + imageW;
//    image.style.width = imageW + "px";

//    image = document.getElementById('title');
//    imageW = Math.floor(20 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=top.png&width=" + imageW + "' )";
//    image = document.getElementById('header');
//    imageW = Math.floor(19 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=bottom.png&width=" + imageW + "' )";

//    image = document.getElementById('main-top-left');
//    imageW = Math.floor(800 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=top-left.png&width=" + imageW + "' )";
//    image = document.getElementById('main-top-right');
//    imageW = Math.floor(21 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=top-right.png&width=" + imageW + "' )";

//    image = document.getElementById('main-left');
//    imageW = Math.floor(800 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=left.png&width=" + imageW + "' )";
//    image = document.getElementById('main-right');
//    imageW = Math.floor(21 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=right.png&width=" + imageW + "' )";

//    image = document.getElementById('main-bottom-left');
//    imageW = Math.floor(800 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=bottom-left.png&width=" + imageW + "' )";
//    image = document.getElementById('main-bottom-right');
//    imageW = Math.floor(19 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=bottom-right.png&width=" + imageW + "' )";



//    image = document.getElementById('sidebar-top-left');
//    imageW = Math.floor(800 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=top-left.png&width=" + imageW + "' )";
//    image = document.getElementById('sidebar-top-right');
//    imageW = Math.floor(21 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=top-right.png&width=" + imageW + "' )";

//    image = document.getElementById('sidebar-left');
//    imageW = Math.floor(800 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=left.png&width=" + imageW + "' )";
//    image = document.getElementById('sidebar-right');
//    imageW = Math.floor(21 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=right.png&width=" + imageW + "' )";

//    image = document.getElementById('sidebar-bottom-left');
//    imageW = Math.floor(800 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=bottom-left.png&width=" + imageW + "' )";
//    image = document.getElementById('sidebar-bottom-right');
//    imageW = Math.floor(19 * size / 100);
//    image.style.backgroundImage = "url( 'resources/scaleimage.php?image=bottom-right.png&width=" + imageW + "' )";

    /*
    frame = document.getElementById( 'frame' );
    frameW = Math.floor( 336 * size / 100 );
    frameH = Math.floor( 280 * size / 100 );
    if( frame.document != undefined ) {
    frame.document.body.style.fontSize = size + "%";
    }
    else {
    frame.contentDocument.body.style.fontSize = size + "%";
    }

    if( frame.style != undefined ) {
    frame.style.width = frameW + "px";
    frame.style.height = frameH + "px";
    }
    else {
    frame.width = frameW;
    frame.height = frameH;
    }
    */

}

function resetLayout() {
    setFontSize(100);
    document.getElementById('header').style.width = null;
    document.getElementById('footer').style.width = null;
}

function setContentWidth() {
    content = document.getElementById('content').offsetWidth;
    sidebar = content
    content = (mainW + sidebar) + 1;
    document.getElementById('content').style.width = content + 'px';
    return content;
}