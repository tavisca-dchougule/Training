String.prototype.SubString = function (startIndex,endIndex) {
    var string = this;
    if (startIndex >= string.length || startIndex < 0)
    {
        
        throw new TypeError;
        
       
    }

    if (endIndex >= string.length || endIndex < startIndex)
    {
        
        throw new TypeError;
       
    }
    var answer = "";

    for (i = startIndex; i <endIndex; i++)
    {

        answer += string.charAt(i);
    }

    return answer;
};