var input = "#...##.####.#.......#.##..##.#.,#.##.#..#..#...##..##.##.#.....,#..#####.#......#..#....#.###.#,...#.#.#...#..#.....#..#..#.#..,.#.....##..#...#..#.#...##.....,##.....#..........##..#......##,.##..##.#.#....##..##.......#..,#.##.##....###..#...##...##....,##.#.#............##..#...##..#,###..##.###.....#.##...####....,...##..#...##...##..#.#..#...#.,..#.#.##.#.#.#####.#....####.#.,#......###.##....#...#...#...##,.....#...#.#.#.#....#...#......,#..#.#.#..#....#..#...#..#..##.,#.....#..##.....#...###..#..#.#,.....####.#..#...##..#..#..#..#,..#.....#.#........#.#.##..####,.#.....##..#.##.....#...###....,###.###....#..#..#.....#####...,#..##.##..##.#.#....#.#......#.,.#....#.##..#.#.#.......##.....,##.##...#...#....###.#....#....,.....#.######.#.#..#..#.#.....#,.#..#.##.#....#.##..#.#...##..#,.##.###..#..#..#.###...#####.#.,#...#...........#.....#.......#,#....##.#.#..##...#..####...#..,#.####......#####.....#.##..#..,.#...#....#...##..##.#.#......#,#..###.....##.#.......#.##...##";

//input = "......#.#.,#..#.#....,..#######.,.#.#.###..,.#..#.....,..#....#.#,#..#....#.,.##.#..###,##...#..#.,.#....####";
var list = input.split(',')

let currentBest = 0;
let bestPos = {}
for (let y = 0; y < list.length; y++) {
    let row = list[y];
    for (let x = 0; x < row.length; x++) {
        let goodness = evaluateLocation(x, y, list);
        if (goodness > currentBest) {
            currentBest = goodness;
            bestPos = {x:x,y:y}
        }
    }
}

console.log(currentBest);
console.log(bestPos);

function evaluateLocation(x, y, list) {
    if (list[y][x] != '#') {

        return 0;
    }

    let asteroids = 0;

    for (let y2 = 0; y2 < list.length; y2++) {
        let row = list[y];
        for (let x2 = 0; x2 < row.length; x2++) {
            if (list[y2][x2] == '#') {
                let isBlocked = isBlockedF({ x: x, y: y }, { x: x2, y: y2 }, list)
                if (!isBlocked) {
                    asteroids++;
                }
            }
        }
    }
    return asteroids;
}

function isBlockedF(ass1, ass2, list) {
    if (ass1.x === ass2.x && ass1.y === ass2.y)
        return true;

    let difX = ass2.x - ass1.x;
    let difY = ass2.y - ass1.y;

    let gcd = gcd_two_numbers(difX, difY);

    difX = difX / gcd;
    difY = difY / gcd;

    let currentPosition = { x: ass1.x + difX, y: ass1.y + difY}
    if(difX > 0){
        if(difY > 0){
            while (currentPosition.x <= ass2.x && currentPosition.y <= ass2.y && currentPosition.y < list.length && currentPosition.x < list[0].length){

                if(currentPosition.x === ass2.x && currentPosition.y === ass2.y){
                    return false;
                }
                else if(list[currentPosition.y][currentPosition.x] === '#'){
                    return true;
                }else{
                    currentPosition = {x: currentPosition.x + difX, y: currentPosition.y + difY};
                }
            }
            return false;

        }else{
            while (currentPosition.x <= ass2.x && currentPosition.y >= ass2.y && currentPosition.x >= 0 && currentPosition.y >= 0 && currentPosition.x < list[0].length){

                if(currentPosition.x === ass2.x && currentPosition.y === ass2.y){
                    return false;
                }
                else if(list[currentPosition.y][currentPosition.x] === '#'){
                    return true;
                }else{
                    currentPosition = {x: currentPosition.x + difX, y: currentPosition.y + difY};
                }
            }
            return false;
        }
        
    }else{
        if(difY > 0){
            while (currentPosition.x >= ass2.x && currentPosition.y <= ass2.y && currentPosition.x >= 0 && currentPosition.y >= 0 && currentPosition.y < list.length){

                if(currentPosition.x === ass2.x && currentPosition.y === ass2.y){
                    return false;
                }
                else if(list[currentPosition.y][currentPosition.x] === '#'){
                    return true;
                }else{
                    currentPosition = {x: currentPosition.x + difX, y: currentPosition.y + difY};
                }
            }
            return false;

        }else{
            while (currentPosition.x >= ass2.x && currentPosition.y >= ass2.y && currentPosition.x >= 0 && currentPosition.y >= 0 ){

                if(currentPosition.x === ass2.x && currentPosition.y === ass2.y){
                    return false;
                }
                else if(list[currentPosition.y][currentPosition.x] === '#'){
                    return true;
                }else{
                    currentPosition = {x: currentPosition.x + difX, y: currentPosition.y + difY};
                }
            }
            return false;
        }
    }
   

}

// https://www.w3resource.com/javascript-exercises/javascript-math-exercise-8.php
function gcd_two_numbers(x, y) {
    if ((typeof x !== 'number') || (typeof y !== 'number'))
        return false;
    x = Math.abs(x);
    y = Math.abs(y);
    while (y) {
        var t = y;
        y = x % y;
        x = t;
    }
    return x;
}
