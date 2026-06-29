import * as THREE from 'https://unpkg.com/three@0.162.0/build/three.module.js';
const textureLoader1 =
    new THREE.TextureLoader();


khodecore.style.height = window.innerWidth + 'px'
khodecore.style.width = window.innerWidth + 'px'
const scene = new THREE.Scene();
scene.background = new THREE.Color(0x050505);
const tex = new THREE.TextureLoader
const camera = new THREE.PerspectiveCamera(
    45,
    1,
    0.1,
    1000
);


camera.position.set(0, -1, 25);

const renderer = new THREE.WebGLRenderer({
    antialias: true,
    alpha: true
});

renderer.setSize(
    khodecore.clientWidth,
    khodecore.clientHeight
);

renderer.setPixelRatio(window.devicePixelRatio);

document.body.appendChild(renderer.domElement);


// =====================
// LIGHTS
// =====================

scene.add(
    new THREE.AmbientLight(
        0xffffff,
        4.5
    )
);

const light1 = new THREE.DirectionalLight(
    0x575555,
    4
);

light1.position.set(
    10,
    15,
    10
);

scene.add(light1);

const light11 = new THREE.DirectionalLight(
    0x575555,
    4
);

light11.position.set(
    51,
    10,
    110
);
scene.add(light11);

const light111 = new THREE.DirectionalLight(
    0x575555,
    12
);

light111.position.set(
    -191,
    0,
    110
);

const light1111 = new THREE.DirectionalLight(
    0x575555,
    19
);

light1111.position.set(
    -87,
    60,
    70
);
scene.add(light1111);

const light11111 = new THREE.DirectionalLight(
    0x575555,
    19
);

light11111.position.set(
    -17,
    60,
    -120
);
scene.add(light11111);

const light2 = new THREE.DirectionalLight(
    0x575555,
    2
);

light2.position.set(
    -10,
    -5,
    -10
);

scene.add(light2);


// =====================
// SPHERE
// =====================

const sphereRadius = 5;
const sphereColor =
    textureLoader1.load(
        "/sitetemplate/assets/image/otherimg//t6.jpg"
    );

const sphereNormal =
    textureLoader1.load(
        "/sitetemplate/assets/image/otherimg//t6.jpg"
    );

const sphereRoughness =
    textureLoader1.load(
        "/sitetemplate/assets/image/otherimg//t6.jpg"
    );
const sphere = new THREE.Mesh(

    new THREE.SphereGeometry(
        sphereRadius,
        128,
        128


    ),

    new THREE.MeshPhysicalMaterial({


        map: sphereColor,

        normalMap: sphereNormal,

        roughnessMap: sphereRoughness,

        metalness: 0.85,

        roughness: 0.45,

        clearcoat: 0.1,

        clearcoatRoughness: 0.07,

        reflectivity: 1,

        envMapIntensity: 1.2


    })

);



scene.add(sphere);



// =====================
// CURVED PANEL
// =====================

function createCurvedPanel(
    width,
    height,
    curve = 3
) {

    const geometry =
        new THREE.PlaneGeometry(
            width,
            height,
            20,
            20
        );

    const pos =
        geometry.attributes.position;

    for (let i = 0; i < pos.count; i++) {

        const x = pos.getX(i);

        const z =

            Math.sqrt(
                curve * curve -
                x * x - curve
            );

        pos.setZ(i, z);
    }

    geometry.computeVertexNormals();

    return geometry;
}


// =====================
// FIBONACCI POINTS
// =====================

function fibonacciSphere(count) {

    const points = [];

    const golden =
        Math.PI *
        (3 - Math.sqrt(5));

    for (let i = 0; i < count; i++) {

        const y =
            1 -
            (i / (count - 1)) * 2;

        const radius =
            Math.sqrt(1 - y * y);

        const theta =
            golden * i;

        const x =
            Math.cos(theta) * radius;

        const z =
            Math.sin(theta) * radius;

        points.push(
            new THREE.Vector3(
                x,
                y,
                z
            )
        );
    }

    return points;
}


// =====================
// PANELS
// =====================

const panelGroup =
    new THREE.Group();

scene.add(panelGroup);

const points =
    fibonacciSphere(60);
let add = 0
for (const dir of points) {
    ++add

    const width =
        THREE.MathUtils.randFloat(
            1.3,
            1.7
        );

    const height =
        THREE.MathUtils.randFloat(
            2,
            2.5
        );

    const offset =
        THREE.MathUtils.randFloat(
            -1.2, -0.9
        );

    const panel =
        new THREE.Mesh(

            createCurvedPanel(
                width,
                height,
                THREE.MathUtils.randFloat(
                    2,
                    5
                )
            ),

            new THREE.MeshPhysicalMaterial({
                map: tex.load(`sitetemplate/assets/image/coreimg/${add}.png`),


                metalness: 1,
                roughness: 0.25,
                side: THREE.DoubleSide

            })

        );

    panel.position.copy(
        dir.clone().multiplyScalar(
            sphereRadius + offset
        )
    );

    panel.lookAt(
        0,
        0,
        0
    );
    panel.rotateY(Math.PI)

    panel.rotateZ(
        THREE.MathUtils.randFloatSpread(
            0.5
        )
    );

    panelGroup.add(panel);
}


// =====================
// ANIMATION
// =====================

function animate() {

    requestAnimationFrame(
        animate
    );

    panelGroup.rotation.y += 0.002;
    sphere.rotation.y += 0.002;

    renderer.render(
        scene,
        camera
    );
}

animate();


// =====================
// RESIZE
// =====================
const co = document.querySelector('.core')
const ph = document.querySelector('.photo')

scene.background = null
khodecore.appendChild(renderer.domElement)
renderer.domElement.style.height = window.innerWidth
renderer.domElement.style.background = 'none'
co.style.height = 920 * a + 'px'
