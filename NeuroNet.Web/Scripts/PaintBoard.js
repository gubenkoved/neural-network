var paintBoard;
var context;
var intensityField;
var xResolution;
var yResolution;

var brushRadius = 1;

var mousePressed = [false, false, false];

// Calling when DOM is ready
$(function () {
    init();
});

function init() {
    paintBoard = $("#paint-board");

    if (paintBoard && paintBoard[0].getContext) {

        context = paintBoard[0].getContext('2d');

        if (context) {

            paintBoard.mousemove(function (event) { paintboardMouseMove(event); });
            paintBoard.mousedown(function (event) { paintboardMouseDown(event); });
            paintBoard.mouseup(function (event) { paintboardMouseUp(event); });

            $(".clear-paint-board-button").click(function() { clearIntensityField(); });

            paintBoard.bind("contextmenu", function(e) {
                return false;
            });

            drawField();

            for (var i = 0; i <= 9; i++) {
                $("#answer").append("<span style=\"color=rgba(255, 255, 255, 1.0);\">" + i + "</span>");
            }

            $("#answer span:first-child").addClass("first-span-answer");
            $("#answer span:last-child").addClass("last-span-answer");

            getNeuronetAnswer();
        }
    }
}

function getBlockWidth() {
    var width = paintBoard.width();
    return width / xResolution;
}

function getBlockHeight() {
    var height = paintBoard.height();
    return height / yResolution;
}

function paintboardMouseDown(event) {

    mousePressed[event.button] = true;

    paintboardMouseMove(event);
}

function paintboardMouseUp(event) {
    mousePressed[event.button] = false;

    getNeuronetAnswer();
}

function brushOn(i, j, value) {

    for (var x = Math.max(0, i - brushRadius); x <= Math.min(xResolution - 1, i + brushRadius); x++) {
        for (var y = Math.max(0, j - brushRadius); y <= Math.min(yResolution - 1, j + brushRadius); y++) {

            if (Math.sqrt((x - i) * (x - i) + (y - j) * (y - j)) <= brushRadius) {
                intensityField[x][y] = value;
                drawBlockIJ(x, y, intensityField[x][y]);
            }
        
        }
    }
}

function paintboardMouseMove(event) {
    if (mousePressed[0] || mousePressed[2]) {
        var x = event.pageX - paintBoard.offset().left;
        var y = event.pageY - paintBoard.offset().top;

        var i = Math.ceil(x / getBlockWidth()) - 1;
        var j = Math.ceil(y / getBlockHeight()) - 1;

        if (mousePressed[0] == true) {
            brushOn(i, j, 1.0);
        }
        else if (mousePressed[2] == true) {
            brushOn(i, j, 0.0);
        }
        //drawField();
    }
}

function createField(xRes, yRes) {
    xResolution = xRes;
    yResolution = yRes;

    intensityField = new Array(yResolution);

    for (var i = 0; i < yResolution; i++) {
        intensityField[i] = new Array(xResolution);
    }

    clearIntensityField();
}

function getDrawColor(intensity) {

    var a = intensity * 255;

    return "rgb(" + a + "," + a + "," + a + ")";
}

function drawBlockIJ(i, j, intensity) {
    
    var blockWidth = getBlockWidth();
    var blockHeight = getBlockHeight();

    var xBlockStart = i * blockWidth;
    var yBlockStart = j * blockHeight;

    drawBlock(xBlockStart, yBlockStart, blockWidth, blockHeight, intensity);
}

function drawBlock(xBlockStart, yBlockStart, blockWidth, blockHeight, intensity) {

    context.fillStyle = getDrawColor(intensity);

    context.fillRect(xBlockStart + 1, yBlockStart + 1, blockWidth - 1, blockHeight - 1);

}

function drawGrid() {
    
    var width = paintBoard.width();
    var height = paintBoard.height();

    var blockWidth = getBlockWidth();
    var blockHeight = getBlockHeight();

    //context.strokeStyle = "rgba(200, 200, 200, 0.2)";
    context.strokeStyle = "rgb(30, 30, 30)";
    context.lineWidth = 1;

    for (var i = 1; i < xResolution; i++) {
        var x = i * blockWidth + 0.5;

        context.moveTo(x, 0);
        context.lineTo(x, height);
    }

    for (var j = 1; j < yResolution; j++) {
        var y = j * blockHeight + 0.5;

        context.moveTo(0, y);
        context.lineTo(width, y);
    }

    context.stroke();
}

function clearCanvas(color) {
    
    context.fillStyle = color;

    context.fillRect(0, 0, paintBoard.width(), paintBoard.height());
}

function drawField() {

    var blockWidth = getBlockWidth();
    var blockHeight = getBlockHeight();

    clearCanvas("black");

    for (var i = 0; i < xResolution; i++) {
        for (var j = 0; j < yResolution; j++) {

            var xBlockStart = i * blockWidth;
            var yBlockStart = j * blockHeight;

            drawBlock(xBlockStart, yBlockStart, blockWidth, blockHeight, getDrawColor(intensityField[i][j]));
        }
    }

    drawGrid();
}

Array.prototype.max = function () {
    var max = this[0];
    var len = this.length;
    for (var i = 1; i < len; i++) if (this[i] > max) max = this[i];
    return max;
};

Array.prototype.min = function () {
    var min = this[0];
    var len = this.length;
    for (var i = 1; i < len; i++) if (this[i] < min) min = this[i];
    return min;
};

function getAnswerColor(alpha) {
    return "rgba(0,0,0," + alpha + ")";
}

function presentResults(answer) {

    var max = answer.max();
    var min = answer.min();
    
    for (var i = 0; i < 10; i++) {

        var alpha = (answer[i] - min) / (max - min);

        $($("#answer").children()[i]).css("color", getAnswerColor(alpha));
    }
}

function getNeuronetAnswer() {
    $.post(document.URL, "intensityField=" + JSON.stringify(intensityField), function (answer) {
        presentResults(answer);
    });
}

function clearIntensityField() {
    for (var x = 0; x < xResolution; x++) {
        for (var y = 0; y < yResolution; y++) {
            intensityField[x][y] = 0.0;
        }
    }

    drawField();
    getNeuronetAnswer();
}