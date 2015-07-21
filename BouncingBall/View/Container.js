window.ball = window.ball || {}

ball.container = function () {

    var height = (window.innerHeight - 50);
    var width = (window.innerWidth - 50);

    if (ball.previousTop >= height) {
        ball.deltaY = -10;
        return;
    }
    if (ball.previousLeft >= width) {
        ball.deltaX = -10;
        return;
    }
    if (ball.previousTop <= 0) {
        ball.deltaY = 10;
        return;
    }
    if (ball.previousLeft <= 0) {
        ball.deltaX = 10;
        return;
    }
}