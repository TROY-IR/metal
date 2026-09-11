const parts = document.querySelector(".parts");
const detail1 = document.querySelector(".detail1");
const detail2 = document.querySelector(".detail2");
const detail3 = document.querySelector(".detail3");
const add = document.querySelector(".add");
const body1 = document.querySelector(".body1");
const f12 = document.querySelector(".f12");
//    const ba = document.getElementById('idaste');
const a = window.innerWidth / 520;
const a0 = window.innerHeight / window.innerWidth;
const ax = window.innerWidth / 420;
const ah = window.innerHeight / 420;

const width = 720;
const height = 340;

const cornerRadius = 25; // گردی گوشه‌ها
const notchRadius = 65; // شعاع تو رفتگی
const notchCount = 2;

// فاصله بین تو رفتگی‌ها
const notchGap = 45;

// عرض هر تو رفتگی
const notchWidth = notchRadius * 2;

// مجموع فضای مورد نیاز تو رفتگی‌ها
const notchesTotal = 4 * notchWidth + (4 - 1) * notchGap;

// فضای باقی‌مانده برای قسمت‌های صاف
const straightSpace = width - 2 * cornerRadius - notchesTotal;

// تعداد قسمت‌های صاف در بالا
const straightCount = notchCount + 1;

const straightWidth = straightSpace / straightCount;

const notchDepth = 125;
const notchRound = 12;

// ----------------------------
// ساخت مسیر SVG
// ----------------------------

let d = `
        M ${cornerRadius} 0
    `;

// شروع قسمت بالایی
let x = cornerRadius;

for (let i = 0; i < notchCount; i++) {
    // قسمت صاف قبل از تو رفتگی
    x += straightWidth;

    d += `L ${x} 0 `;

    // تو رفتگی نیم دایره‌ای
    const round = 12;

    d += `
        C ${x + round} 0,
          ${x + round} ${notchDepth},
          ${x + notchWidth / 2} ${notchDepth}

        C ${x + notchWidth - round} ${notchDepth},
          ${x + notchWidth - round} 0,
          ${x + notchWidth} 0
    `;

    x += notchWidth;

    // فاصله تا تو رفتگی بعدی
    if (i < notchCount - 1) {
        x += notchGap;
        d += `L ${x} 0 `;
    }
}

// قسمت صاف آخر
d += `
        L ${width - cornerRadius} 0

        Q ${width} 0
          ${width} ${cornerRadius}

        L ${width} ${height - cornerRadius}

        Q ${width} ${height}
          ${width - cornerRadius} ${height}

        L ${cornerRadius} ${height}

        Q 0 ${height}
          0 ${height - cornerRadius}

        L 0 ${cornerRadius}

        Q 0 0
          ${cornerRadius} 0

        Z
    `;

const svg = `
    <svg
        width="100%"
        height="100%"
        viewBox="0 0 ${width} ${height}"
        xmlns="http://www.w3.org/2000/svg"
        preserveAspectRatio="none"
    class="svv"

    >
        <path
            d="${d}"
            fill="rgba(18,18,18)"

        />
    </svg>
    `;

Array.from(document.querySelectorAll(".parts1")).forEach((iner) => {
    iner.innerHTML += svg;
});
const svv = document.querySelector(".svv");
svv.classList.add("svv1");


add.addEventListener("click", () => {
    body1.style.display = "flex"
})
f12.addEventListener("click", () => {
    body1.style.display = "none"
})

Array.from(parts.children).forEach(function (ch, ind) {
    ch.addEventListener("click", (c) => {
        Array.from(parts.children).forEach((ch1) => {
            ch1.style.height = 100 + "%";
        });

        ch.style.height = 95 + "%";

        if (ind == 0) {
            detail2.style.display = "none";
            detail3.style.display = "none";
            detail1.style.display = "flex";
        } else if (ind == 1) {
            detail1.style.display = "none";
            detail3.style.display = "none";
            detail2.style.display = "flex";
        } else if (ind == 2) {
            detail1.style.display = "none";
            detail2.style.display = "none";
            detail3.style.display = "flex";
        }
    });
});




