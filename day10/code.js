var input = "#...##.####.#.......#.##..##.#.,#.##.#..#..#...##..##.##.#.....,#..#####.#......#..#....#.###.#,...#.#.#...#..#.....#..#..#.#..,.#.....##..#...#..#.#...##.....,##.....#..........##..#......##,.##..##.#.#....##..##.......#..,#.##.##....###..#...##...##....,##.#.#............##..#...##..#,###..##.###.....#.##...####....,...##..#...##...##..#.#..#...#.,..#.#.##.#.#.#####.#....####.#.,#......###.##....#...#...#...##,.....#...#.#.#.#....#...#......,#..#.#.#..#....#..#...#..#..##.,#.....#..##.....#...###..#..#.#,.....####.#..#...##..#..#..#..#,..#.....#.#........#.#.##..####,.#.....##..#.##.....#...###....,###.###....#..#..#.....#####...,#..##.##..##.#.#....#.#......#.,.#....#.##..#.#.#.......##.....,##.##...#...#....###.#....#....,.....#.######.#.#..#..#.#.....#,.#..#.##.#....#.##..#.#...##..#,.##.###..#..#..#.###...#####.#.,#...#...........#.....#.......#,#....##.#.#..##...#..####...#..,#.####......#####.....#.##..#..,.#...#....#...##..##.#.#......#,#..###.....##.#.......#.##...##";

//input = ".#....#####...#..,##...##.#####..##,##...#...#.#####.,..#.....X...###..,..#.#.....#....##";
//input = ".#..##.###...#######,##.############..##.,.#.######.########.#,.###.#######.####.#.,#####.##.#.##.###.##,..#####..#.#########,####################,#.####....###.#.#.##,##.#################,#####.##.###..####..,..######..##.#######,####.##.####...##..#,.#####..#.######.###,##...#.##########...,#.##########.#######,.####.#.###.###.#.##,....##.##.###..#####,.#.#.###########.###,#.#.#.#####.####.###,###.##.####.##.#..##";

var list = input.split(',').map(string => string.split(''));

let currentBest = 0;
let bestPos = {}
for (let y = 0; y < list.length; y++) {
    let row = list[y];
    for (let x = 0; x < row.length; x++) {
        let goodness = evaluateLocation(x, y, list);
        if (goodness > currentBest) {
            currentBest = goodness;
            bestPos = { x: x, y: y }
        }
    }
}

console.log(currentBest);
console.log(bestPos);

var fixList = []
let laserPos = bestPos
list[laserPos.y][laserPos.x] = 'X';

while (thereAreAsteroidsLeft(list)) {


    fixUp(laserPos, list)
    let r = makeQuad1(laserPos, list)
    let s = fixQuad1(laserPos, r, list)
    fixRight(laserPos, list)
    let r2 = makeQuad2(laserPos, list)
    let s2 = fixQuad2(laserPos, r2, list)
    fixDown(laserPos, list)
    let r3 = makeQuad3(laserPos, list);
    fixQuad3(laserPos, r3, list)
    fixLeft(laserPos, list)
    let r4 = makeQuad4(laserPos, list);
    fixQuad4(laserPos, r4, list)


}

console.log(fixList[199])
// while(thereAreAsteroidsLeft(list)){
//     burnAsteroids(direction,laserPos, list)
//     direction = fixQuad1(laserPos, list)

// }

function fixUp(laserPos, list) {
    for (let i = laserPos.y; i >= 0; i--) {
        let pos = { x: laserPos.x, y: i }
        if (!isBlockedF(laserPos, pos, list)) {
            list[pos.y][pos.x] = 'A'
            fixList.push(pos)
            return;
        }
    }
}

function fixRight(laserPos, list) {
    for (let i = laserPos.x; i < list[0].length; i++) {
        let pos = { x: i, y: laserPos.y }
        if (!isBlockedF(laserPos, pos, list)) {
            list[pos.y][pos.x] = 'A'
            fixList.push(pos)
            return;
        }
    }
}
function fixDown(laserPos, list) {
    for (let i = laserPos.y; i < list.length; i++) {
        let pos = { x: laserPos.x, y: i }
        if (!isBlockedF(laserPos, pos, list)) {
            list[pos.y][pos.x] = 'A'
            fixList.push(pos)
            return;
        }
    }
}

function fixLeft(laserPos, list) {
    for (let i = laserPos.x; i >= 0; i--) {
        let pos = { x: i, y: laserPos.y }
        if (!isBlockedF(laserPos, pos, list)) {
            list[pos.y][pos.x] = 'A'
            fixList.push(pos)
            return;
        }
    }
}

function fixQuad1(laserPos, ratings, list) {
    let quadlist = []
    while (ratingsHaveAllBeenUsed(ratings)) {
        let minRelativePos = findMinValue(ratings);
        let minPos = { x: laserPos.x + minRelativePos.x + 1, y: laserPos.y - minRelativePos.y - 1 }
        if (!isBlockedF(laserPos, minPos, list)) {
            fixList.push(minPos)
            quadlist.push(minPos)
        }
    }

    quadlist.forEach(item => list[item.y][item.x] = 'A')

}

function fixQuad2(laserPos, ratings, list) {
    let quadlist = []
    while (ratingsHaveAllBeenUsed(ratings)) {
        let maxRelativePos = findMaxValue(ratings);
        let maxPos = { x: laserPos.x + maxRelativePos.x + 1, y: laserPos.y + maxRelativePos.y + 1 }
        if (!isBlockedF(laserPos, maxPos, list)) {
            fixList.push(maxPos)
            quadlist.push(maxPos)
        }
    }

    quadlist.forEach(item => list[item.y][item.x] = 'A')

}

function fixQuad3(laserPos, ratings, list) {
    let quadlist = []
    while (ratingsHaveAllBeenUsed(ratings)) {
        let relativePos = findMinValue(ratings);
        let pos = { x: laserPos.x - relativePos.x - 1, y: laserPos.y + relativePos.y + 1 }
        if (!isBlockedF(laserPos, pos, list)) {
            fixList.push(pos)
            quadlist.push(pos)
        }
    }

    quadlist.forEach(item => list[item.y][item.x] = 'A')

}

function fixQuad4(laserPos, ratings, list) {
    let quadlist = []
    while (ratingsHaveAllBeenUsed(ratings)) {
        let relativePos = findMaxValue(ratings);
        let pos = { x: laserPos.x - relativePos.x - 1, y: laserPos.y - relativePos.y - 1 }
        if (!isBlockedF(laserPos, pos, list)) {
            fixList.push(pos)
            quadlist.push(pos)
        }
    }

    quadlist.forEach(item => list[item.y][item.x] = 'A')

}
function ratingsHaveAllBeenUsed(ratings) {
    return ratings.some(r => r.some(rr => Math.abs(rr) !== 999999))
}

function findMinValue(ratings) {
    let minValue = 9999999;
    let minPos = {}
    for (let y = 0; y < ratings.length; y++) {
        let row = ratings[y];
        for (let x = 0; x < row.length; x++) {
            if (ratings[y][x] < minValue) {
                minValue = ratings[y][x];
                minPos = { x: x, y: y }
            }
        }
    }
    ratings[minPos.y][minPos.x] = 999999

    return minPos;
}

function findMaxValue(ratings) {
    let maaxValue = 0;
    let maxPos = {}
    for (let y = 0; y < ratings.length; y++) {
        let row = ratings[y];
        for (let x = 0; x < row.length; x++) {
            if (ratings[y][x] > maaxValue) {
                maaxValue = ratings[y][x];
                maxPos = { x: x, y: y }
            }
        }
    }
    ratings[maxPos.y][maxPos.x] = -999999

    return maxPos;
}

function makeQuad1(laserPos, list) {
    let ratings = []
    for (let y = laserPos.y - 1; y >= 0; y--) {
        let row = [];
        for (let x = laserPos.x + 1; x < list[y].length; x++) {
            let difX = x - laserPos.x;
            let difY = Math.abs(y - laserPos.y);
            row.push(difX / difY)
        }
        ratings.push(row);
    }
    return ratings

}

function makeQuad2(laserPos, list) {
    let ratings = []
    for (let y = laserPos.y + 1; y < list.length; y++) {
        let row = [];
        for (let x = laserPos.x + 1; x < list[y].length; x++) {
            let difX = x - laserPos.x;
            let difY = Math.abs(y - laserPos.y);
            row.push(difX / difY)
        }
        ratings.push(row);
    }
    return ratings

}

function makeQuad3(laserPos, list) {
    let ratings = []
    for (let y = laserPos.y + 1; y < list.length; y++) {
        let row = [];
        for (let x = laserPos.x - 1; x >= 0; x--) {
            let difX = laserPos.x - x;
            let difY = Math.abs(y - laserPos.y);
            row.push(difX / difY)
        }
        ratings.push(row);
    }
    return ratings

}

function makeQuad4(laserPos, list) {
    let ratings = []
    for (let y = laserPos.y - 1; y >= 0; y--) {
        let row = [];
        for (let x = laserPos.x - 1; x >= 0; x--) {
            let difX = laserPos.x - x;
            let difY = Math.abs(y - laserPos.y);
            row.push(difX / difY)
        }
        ratings.push(row);
    }
    return ratings

}


function burnAsteroids(direction, laserPos, list) {
    let pos = { x: laserPos.x, y: laserPos.y };
    if (direction.x > 0) {
        if (direction.y > 0) {
            while (pos.y < list.length && pos.x < list[0].length) {
                let isBlocked = isBlockedF(laserPos, pos, list)
                if (!isBlocked) {
                    list[pos.y][pos.x] = "A";
                    return;
                } else {
                    pos = { x: pos.x + direction.x, y: pos.y + direction.y }
                }

            }


        } else {
            while (pos.y >= 0 && pos.x < list[0].length) {
                let isBlocked = isBlockedF(laserPos, pos, list)
                if (!isBlocked) {
                    list[pos.y][pos.x] = "A";
                    return;
                } else {
                    pos = { x: pos.x + direction.x, y: pos.y + direction.y }
                }

            }
        }

    } else {
        if (direction.y > 0) {
            while (pos.x >= 0 && pos.y >= 0 && pos.y < list.length) {
                let isBlocked = isBlockedF(laserPos, pos, list)
                if (!isBlocked) {
                    list[pos.y][pos.x] = "A";
                    return;
                } else {
                    pos = { x: pos.x + direction.x, y: pos.y + direction.y }
                }

            }

        } else {
            while (pos.x >= 0 && pos.y >= 0) {
                let isBlocked = isBlockedF(laserPos, pos, list)
                if (!isBlocked) {
                    list[pos.y][pos.x] = "A";
                    return;
                } else {
                    pos = { x: pos.x + direction.x, y: pos.y + direction.y }
                }
            }
        }
    }
}

function thereAreAsteroidsLeft(list) {

    for (let y = 0; y < list.length; y++) {
        let row = list[y];
        for (let x = 0; x < row.length; x++) {
            let item = list[y][x];
            if (item === '#')
                return true;
        }
    }

    return false;
}





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

    if (list[ass2.y][ass2.x] !== '#')
        return true;

    let difX = ass2.x - ass1.x;
    let difY = ass2.y - ass1.y;

    let gcd = gcd_two_numbers(difX, difY);

    difX = difX / gcd;
    difY = difY / gcd;

    let currentPosition = { x: ass1.x + difX, y: ass1.y + difY }
    if (difX > 0) {
        if (difY > 0) {
            while (currentPosition.x <= ass2.x && currentPosition.y <= ass2.y && currentPosition.y < list.length && currentPosition.x < list[0].length) {

                if (currentPosition.x === ass2.x && currentPosition.y === ass2.y) {
                    return false;
                }
                else if (list[currentPosition.y][currentPosition.x] === '#') {
                    return true;
                } else {
                    currentPosition = { x: currentPosition.x + difX, y: currentPosition.y + difY };
                }
            }
            return false;

        } else {
            while (currentPosition.x <= ass2.x && currentPosition.y >= ass2.y && currentPosition.x >= 0 && currentPosition.y >= 0 && currentPosition.x < list[0].length) {

                if (currentPosition.x === ass2.x && currentPosition.y === ass2.y) {
                    return false;
                }
                else if (list[currentPosition.y][currentPosition.x] === '#') {
                    return true;
                } else {
                    currentPosition = { x: currentPosition.x + difX, y: currentPosition.y + difY };
                }
            }
            return false;
        }

    } else {
        if (difY > 0) {
            while (currentPosition.x >= ass2.x && currentPosition.y <= ass2.y && currentPosition.x >= 0 && currentPosition.y >= 0 && currentPosition.y < list.length) {

                if (currentPosition.x === ass2.x && currentPosition.y === ass2.y) {
                    return false;
                }
                else if (list[currentPosition.y][currentPosition.x] === '#') {
                    return true;
                } else {
                    currentPosition = { x: currentPosition.x + difX, y: currentPosition.y + difY };
                }
            }
            return false;

        } else {
            while (currentPosition.x >= ass2.x && currentPosition.y >= ass2.y && currentPosition.x >= 0 && currentPosition.y >= 0) {

                if (currentPosition.x === ass2.x && currentPosition.y === ass2.y) {
                    return false;
                }
                else if (list[currentPosition.y][currentPosition.x] === '#') {
                    return true;
                } else {
                    currentPosition = { x: currentPosition.x + difX, y: currentPosition.y + difY };
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
