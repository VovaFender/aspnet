function TriangleSquare() {
    self = this;
    var x;
    var oldColor;

    this.init = function () {

        x = new Boolean(true);
        oldColor = new String($(".square").css("color"));

        $("label").click(function () {
            if (x) {
                $(".square").css("color", "black");
                x = false;
            } else {
                x = true;
                $(".square").css("color", oldColor);
            }
        });
    }
    
}

var functionName = null;

$().ready(function () {
    functionName = new TriangleSquare();
    functionName.init();        
});
