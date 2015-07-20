var playerOneSymbol = "X";
var playerTwoSymbol = "O";
var turn = "p1";

var playerOneMove=["","","","","","","","",""];
var playerTwoMove = ["", "", "", "", "", "", "", "", ""];
var isGameOn = true;
var buttonIdList = [null, null, null, null, null, null, null, null, null];
function clickHandler(event)
{
    if (isGameOn == false) {
        alert("Game Complited.\nRestart the Game.");
        return;
    }
   
    var id = event.target.id;
    var source = document.getElementById(id);
   
    if (turn == "p1") {
       
        var index = parseInt(id);
        if (buttonIdList[index] == null)
            buttonIdList[index] = source;
        else {
            alert("Already Occupied.");
            return;
        }
        source.value = "X";
        playerOneMove[index] = "X";

        var win = isPlayerWin(playerOneMove,playerOneSymbol);
        if (win == 1) {
            alert("Player One Win.");
            isGameOn = false;
            return;
        }
        if (isGameDraw() == true) {
            alert("Draw");
            isGameOn = false;
            return;
        }
        turn = "p2";
        return;
    }
    if (turn == "p2") {
       

        var index = parseInt(id);
        if (buttonIdList[index] == null)
            buttonIdList[index] = source;
        else {
            alert("Already Occupied.");
            return;
        }
        
        source.value = "O";
        playerTwoMove[index] = "O";

        var win = isPlayerWin(playerTwoMove,playerTwoSymbol);
        if (win == 1) {
            alert("Player Two Win.");
            isGameOn = false;
            return;
        }
        if (isGameDraw() == true) {
            alert("Draw");
            isGameOn = false;
            return;
        }
        turn = "p1";
        return;
    }   
}

function isGameDraw()
{
    for (var i = 0; i < 9; i++) {
        if (buttonIdList[i] == null)
            return false;
    }
    return true;
}

function isPlayerWin(player,symbol) {
    if (player[0] == symbol && player[1] == symbol && player[2] == symbol)
        return 1;
    if (player[3] == symbol && player[4] == symbol && player[5] == symbol)
        return 1;
    if (player[6] == symbol && player[7] == symbol && player[8] == symbol)
        return 1;
    if (player[0] == symbol && player[3] == symbol && player[6] == symbol)
        return 1;
    if (player[1] == symbol && player[4] == symbol && player[7] == symbol)
        return 1;
    if (player[2] == symbol && player[5] == symbol && player[8] == symbol)
        return 1;
    if (player[0] == symbol && player[4] == symbol && player[8] == symbol)
        return 1;
    if (player[2] == symbol && player[4] == symbol && player[6] == symbol)
        return 1;
    else
        return 0;
}

function reStartGame() {
     turn = "p1";
     playerOneMove = ["", "", "", "", "", "", "", "", ""];
     playerTwoMove = ["", "", "", "", "", "", "", "", ""];
     isGameOn = true;
     for (var i = 0; i < 9; i++) {
         if(buttonIdList[i]!=null)
             buttonIdList[i].value = " ";
         buttonIdList[i] = null;
     }

}