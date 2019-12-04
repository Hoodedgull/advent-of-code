

var start = 153517
var end = 630395

let count = 0;
for(let i = start; i <= end; i++){
    if(hasExactDouble(i.toString()) && isNonDecreasing(i.toString()))
        count++;
}

function hasDouble(string){
    
    for(let i = 1; i < string.length; i ++){
        if(string[i] === string[i-1])
            return true;
    }
    return false;
}

function hasExactDouble(string){
    
    for(let i = 1; i < string.length; i ++){
        if(string[i] === string[i-1] && (i === 1 || string[i-2] !== string[i]) && (i=== string.length-1 || string[i+1] !== string[i]))
            return true;
    }
    return false;
}

function isNonDecreasing(string){
    for(let i = 1; i < string.length; i++){
        if(string[i] < string[i-1])
            return false;
    }
    return true;
}

console.log(count)