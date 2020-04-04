const equation_text = document.getElementById("equationText");  //text showing full current equation
equation_text.innerText = "";
const result_text = document.getElementById("resultText");      //test showing current number/result

const numbers_btn = document.querySelectorAll(".number");       //number buttons
const opMulti_btn = document.querySelectorAll(".multi");        //operand buttons working with multiple numbers
const opSingle_btn = document.querySelectorAll(".single");      //operand buttons working a single number

const equals_btn = document.querySelector(".equals");
const control_btn = document.querySelectorAll(".control"); 

const dot_btn = document.querySelector(".dot");
const sign_btn = document.querySelector(".sign");

let pNumber = 0;        //previous saved number
let cNumber = 0;        //current number being entered
let cOperand = "";      //current operand waiting to be executed
let regexEq = /=\-?\d+$/;
let newnr = true;

numbers_btn.forEach(function (nrb) {        //sets actions on number button click
    nrb.addEventListener("click", () => handleNumber(nrb.innerText))
});
opSingle_btn.forEach(function (ops) {       //sets actions on single operand button click
    ops.addEventListener("click", () => handleSingleOperand(ops.innerText))
});
opMulti_btn.forEach(function (opm) {        //sets actions on multi operand button click
    opm.addEventListener("click", () => handleMultiOperand(opm.innerText));
});

equals_btn.addEventListener("click", () => handleEquals()); //sets actions on equals button click
control_btn.forEach(function (ctr) {        //sets actions on control button click
    ctr.addEventListener("click", () => handleControl(ctr.innerText));
});

sign_btn.addEventListener("click", () => handleSign());
dot_btn.addEventListener("click", () => handleDot());

const handleNumber = function (nrb) {
    console.log("Number " + nrb);

    if (regexEq.test(equation_text.innerHTML)) {
        equation_text.innerHTML = "";
        cNumber = 0;
    }
    if (newnr) {
        result_text.setAttribute("value", nrb);
        newnr = false;
    }
    else
        result_text.setAttribute("value", result_text.getAttribute("value") + nrb);
    cNumber = Number(result_text.getAttribute("value"));
}

const handleSingleOperand = function (opr) {
    console.log("Single " + opr);

    switch (opr) {
        case "1/X":
            equation_text.innerText += `(1/${cNumber})`;
            cNumber = Math.round((1 / cNumber + Number.EPSILON) * 100) / 100;
            break;
        case "X2":
            equation_text.innerText += `(${cNumber}^2)`;
            cNumber = Math.round((cNumber * cNumber + Number.EPSILON) * 100) / 100;
            break;
        case "√X":
            equation_text.innerText += `(√${cNumber})`;
            cNumber = Math.round((Math.sqrt(cNumber) + Number.EPSILON) * 100) / 100;
            break;
    }
    handleEquals();

    newnr = true;
}

const handleMultiOperand = function (opr) {
    console.log("Multi " + opr);

    if (equation_text.innerHTML === "")
        equation_text.innerText += cNumber;
    if (cOperand === "") {        
        pNumber = cNumber;
        equation_text.innerText += opr;
    }
    else {
        pNumber = doMath();
        equation_text.innerText += cNumber + opr;
    }
    cOperand = opr;
    result_text.setAttribute("value", pNumber);
    cNumber = 0;

    newnr = true;
}

const doMath = function () {
    switch (cOperand) {
        case "^":
            return Math.round((Math.pow(pNumber, cNumber) + Number.EPSILON) * 100) / 100;
        case "/":
            return Math.round((pNumber / cNumber + Number.EPSILON) * 100) / 100;
        case "*":
            return Math.round((pNumber * cNumber + Number.EPSILON) * 100) / 100;
        case "-":
            return Math.round((pNumber - cNumber + Number.EPSILON) * 100) / 100;
        case "+":
            return Math.round((pNumber + cNumber + Number.EPSILON) * 100) / 100;
    }
}

const handleEquals = function () {
    console.log("Equals");

    if (cOperand === "")
        pNumber = cNumber;        
    else {
        let temp = cNumber;
        cNumber = doMath();
        pNumber = temp;
    }
    result_text.setAttribute("value", cNumber);
    equation_text.innerText += pNumber + "=" + cNumber;
    cOperand = "";

    newnr = true;
}

const handleControl = function (ctr) {
    console.log("Control " + ctr);

    switch (ctr) {
        case "CE":
            cNumber = 0;
            break;
        case "C":
            cNumber = 0;
            pNumber = 0;
            cOperand = "";
            equation_text.innerText = "";
            break;
        case "<=":
            let str = result_text.getAttribute("value").slice(0, -1);
            if (Math.abs(cNumber) < 10)
                cNumber = 0;
            else
                cNumber = Number(str);
            break;
    }
    result_text.setAttribute("value", cNumber);
}

const handleSign = function () {
    console.log("Sign");

    cNumber = -cNumber;
    result_text.setAttribute("value", cNumber);
}

const handleDot = function () {
    console.log("Dot");

    if (regexEq.test(equation_text.innerHTML)) {
        equation_text.innerHTML = "";
        cNumber = 0;
    }
    if (newnr) {
        result_text.setAttribute("value", "0.");
        newnr = false;
    }
    else if (!result_text.getAttribute("value").includes("."))
        result_text.setAttribute("value", result_text.getAttribute("value") + ".");
    cNumber = Number(result_text.getAttribute("value"));
}