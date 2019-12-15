

//<x=-7, y=17, z=-11>
// <x=9, y=12, z=5>
// <x=-9, y=0, z=-4>
// <x=4, y=6, z=0>
var moons = [
    { pos: { x: -7, y: 17, z: -11 }, vel: { x: 0, y: 0, z: 0 } },
    { pos: { x: 9, y: 12, z: 5 }, vel: { x: 0, y: 0, z: 0 } },
    { pos: { x: -9, y: 0, z: -4 }, vel: { x: 0, y: 0, z: 0 } },
    { pos: { x: 4, y: 6, z: 0 }, vel: { x: 0, y: 0, z: 0 } }

]

var initialmoons = [
    { pos: { x: -7, y: 17, z: -11 }, vel: { x: 0, y: 0, z: 0 } },
    { pos: { x: 9, y: 12, z: 5 }, vel: { x: 0, y: 0, z: 0 } },
    { pos: { x: -9, y: 0, z: -4 }, vel: { x: 0, y: 0, z: 0 } },
    { pos: { x: 4, y: 6, z: 0 }, vel: { x: 0, y: 0, z: 0 } }

]

// moons = [
//     { pos: { x: -1, y: 0, z: 2 }, vel: { x: 0, y: 0, z: 0 } },
//     { pos: { x: 2, y: -10, z: -7 }, vel: { x: 0, y: 0, z: 0 } },
//     { pos: { x: 4, y: -8, z: 8 }, vel: { x: 0, y: 0, z: 0 } },
//     { pos: { x: 3, y: 5, z: -1 }, vel: { x: 0, y: 0, z: 0 } }

// ]

// moons = [
//     { pos: { x: -8, y: -10, z: 0 }, vel: { x: 0, y: 0, z: 0 } },
//     { pos: { x: 5, y: 5, z: 10 }, vel: { x: 0, y: 0, z: 0 } },
//     { pos: { x: 2, y: -7, z: 3 }, vel: { x: 0, y: 0, z: 0 } },
//     { pos: { x: 9, y: -8, z: -3 }, vel: { x: 0, y: 0, z: 0 } }

// ]



for (let timeStep = 0; timeStep <= 94686774924; timeStep++) {

    // apply gravity
    for (let i = 0; i < moons.length; i++) {
        for (let j = 0; j < moons.length; j++) {
            if (moons[i].pos.x < moons[j].pos.x) {
                moons[i].vel.x += 1;
            } else if (moons[i].pos.x > moons[j].pos.x) {
                moons[i].vel.x -= 1;
            }
            if (moons[i].pos.y < moons[j].pos.y) {
                moons[i].vel.y += 1;
            } else if (moons[i].pos.y > moons[j].pos.y) {
                moons[i].vel.y -= 1;
            }
            if (moons[i].pos.z < moons[j].pos.z) {
                moons[i].vel.z += 1;
            } else if (moons[i].pos.z > moons[j].pos.z) {
                moons[i].vel.z -= 1;
            }
        }
    }

    // apply velocity
    for (let i = 0; i < moons.length; i++) {
        moons[i].pos.x += moons[i].vel.x;
        moons[i].pos.y += moons[i].vel.y;
        moons[i].pos.z += moons[i].vel.z;
    }

    if(    moons[0].pos.x === initialmoons[0].pos.x
        && moons[0].pos.y === initialmoons[0].pos.y
        && moons[0].pos.z === initialmoons[0].pos.z
        && moons[0].vel.x === initialmoons[0].vel.x
        && moons[0].vel.y === initialmoons[0].vel.y
        && moons[0].vel.z === initialmoons[0].vel.z
        && moons[1].pos.x === initialmoons[1].pos.x
        && moons[1].pos.y === initialmoons[1].pos.y
        && moons[1].pos.z === initialmoons[1].pos.z
        && moons[1].vel.x === initialmoons[1].vel.x
        && moons[1].vel.y === initialmoons[1].vel.y
        && moons[1].vel.z === initialmoons[1].vel.z
        && moons[2].pos.x === initialmoons[2].pos.x
        && moons[2].pos.y === initialmoons[2].pos.y
        && moons[2].pos.z === initialmoons[2].pos.z
        && moons[2].vel.x === initialmoons[2].vel.x
        && moons[2].vel.y === initialmoons[2].vel.y
        && moons[2].vel.z === initialmoons[2].vel.z
        ){
            console.log(timeStep);
            break;
        }

}

var totalE =0;
for (let i = 0; i < moons.length; i++) {
    let potE = 0;
    let kinE = 0;
    potE += Math.abs(moons[i].pos.x);
    potE += Math.abs(moons[i].pos.y);
    potE += Math.abs(moons[i].pos.z);
    kinE += Math.abs(moons[i].vel.x);
    kinE += Math.abs(moons[i].vel.y);
    kinE += Math.abs(moons[i].vel.z);
    totalE += (potE * kinE);
}

