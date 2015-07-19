
var previousLeft = 0;
var previousTop = 0;
var deltaX = 10;
var deltaY = 10;

function start() {
     setInterval(bounce, 20);
    
}
function bounce()
{
    var height = (window.innerHeight-50);
    var width = (window.innerWidth-50);
        previousLeft += deltaX;
        previousTop += deltaY;
        var element = document.getElementById('circle');
        element.style.background = "red";
        element.style.left = previousLeft + "px";
        element.style.top = previousTop + "px";
            
       
        if (previousTop >= height) {
            deltaY = -10;
            return;
        }
        if (previousLeft >= width) {
            deltaX = -10;
            return;
        }
        if (previousTop <= 0) {
            deltaY = 10;
            return;
        }
        if (previousLeft <= 0) {
            deltaX = 10;
            return;
        }

}
