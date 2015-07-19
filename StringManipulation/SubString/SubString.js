String.prototype.SubString = function (startIndex,endIndex) {
    var string = this;
    if (startIndex >= string.length || startIndex < 0)
    {
        alert('Invalid Start Index.');
        return;
    }

    if (endIndex >= string.length || endIndex < startIndex)
    {
        alert('Invalid End Index.');
        return;
    }
    var answer = "";

    for (i = startIndex; i <endIndex; i++)
    {

        answer += string.charAt(i);
    }

    return answer;
};