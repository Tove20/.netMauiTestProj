
//let textarea = document.querySelector(".resize-ta");
//textarea.addEventListener("keyup", () => {
//    textarea.style.height = calcHeight(textarea.value) + "px";
//});


function calcHeight(value) {
    let numberOfLineBreaks = (value.match(/\n/g) || []).length;
    // min-height + lines x line-height + padding + border
    let newHeight = 20 + numberOfLineBreaks * 20 + 12 + 2;
    return newHeight;
}
jQuery(document).ready(
    () => {

        let textareaSf = document.querySelector(".resizeboxSf").querySelector("textarea");
        textareaSf.addEventListener("keyup", () => {
            textareaSf.style.height = calcHeight(textareaSf.value) + "px";
        }

        );
        let textareaSf2 = document.querySelector(".resizeboxSf2").querySelector("textarea");
        textareaSf2.addEventListener("keyup", () => {
            textareaSf2.style.height = calcHeight(textareaSf2.value) + "px";
        }

        );
});

