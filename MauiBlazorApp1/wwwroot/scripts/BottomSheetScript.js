function addTitle() {

    var parentId = getIdOfSheet();

    var image = document.createElement("img");
    image.id = "bottom-sheet-image"
    image.src = "/images/monkey.jpg"

    var title = document.createElement("p");
    title.id = "bottom-sheet-title"
    title.innerText = "Monkey.jpg"

    var subline = document.createElement("p");
    subline.id = "bottom-sheet-subline"
    subline.innerText = "28.07.2022 | 4 kB | Finding document"

    var container = document.createElement('div')
    container.id = "bottom-sheet-img-container"

    parentId.appendChild(image);
    container.appendChild(title);
    container.appendChild(subline);
    parentId.appendChild(container);

   

}

function getIdOfSheet() {
    var parentId = '';
    if (document.getElementById('bottom-sheet')) {
        parentId = document.getElementById('bottom-sheet');
    }

    parentId.style.height = '3.5rem !important';

    parentId.parentNode.parentNode.style.maxWidth = '40rem';
    parentId.parentNode.parentNode.style.width = '100%';
    parentId.parentNode.parentNode.style.height = '24.5rem';



    parentId.parentNode.style.maxWidth = '40rem';
    parentId.parentNode.style.width = '100%';
    parentId.parentNode.style.height = '24.5rem';

    return parentId
}