//Replace the ID of Bar, Text and Icons
function changeStyle(value) {

    var parentId = getIdOfBar();

    var text = document.getElementById(parentId.id + "-text");
    text.id = value + "-text";
    var image = document.getElementById(parentId.id  + "-icon");
    image.id = value + "-icon";
    var secondBar = document.getElementById(parentId.id + "-second-bar");
    secondBar.id = value + "-second-bar";

    parentId.id = value;
}


function showSecondaryBar()
{
    var parentId = getIdOfBar();
    if (document.getElementById(parentId.id + "-second-bar")) {
        secondaryBar = document.getElementById(parentId.id + "-second-bar");
        secondaryBar.style.display = "block";
    }
}


function hideSecondaryBar() {
    var parentId = getIdOfBar();
    if (document.getElementById(parentId.id + "-second-bar")) {
        secondaryBar = document.getElementById(parentId.id + "-second-bar");
        secondaryBar.style.display = "none";
    }
}

//add the Searchbar and Remove the Text
function addSearchBar() {
    var parentId = getIdOfBar();
    var tag = document.createElement("form");
    tag.id = "top-bar-searchfield"

    var input = document.createElement("input");
    input.type='search'
    input.placeholder = 'Search...'
    input.id = (parentId.id + "-text");

    var icon = document.createElement("button");
    icon.type = 'submit'
    icon.name = 'Search'
    icon.id = (parentId.id + "-icon");

    tag.appendChild(input);
    tag.appendChild(icon);

    const condText = document.getElementById(parentId.id + "-text") || false;
    if (condText.parentElement == parentId) {
        title = document.getElementById(parentId.id + "-text");
        parentId.removeChild(title)
    }
    const cond = document.getElementById("top-bar-searchfield") || false;
    if (!cond) {
        parentId.appendChild(tag)
    }
    
}

//REmove the Searchbear and Add the text 
function deleteSearchBar() {

    var searchbar = ''
  
    var parentId = getIdOfBar();

    var title = document.createElement("a");
    title.id = parentId.id + '-text';
    title.classList.add('navbar-brand');
    title.href = '';
    title.innerText = 'Title'

    
 
    const condSearchbar = document.getElementById("top-bar-searchfield") || false;
    if (condSearchbar) {
        searchbar = document.getElementById("top-bar-searchfield");
        parentId.removeChild(searchbar)
    }

    const condText = document.getElementById(parentId.id + "-text") || false;
    if (!condText) {
        parentId.appendChild(title)  
    }

}

//Find Top-Bar, the text and the Icons to change the Colors
function getIdOfBar() {
    var parentId = '';
    if (document.getElementById("primary")) {
        parentId = document.getElementById("primary");
    }
    else if (document.getElementById("desaturated")) {
        parentId = document.getElementById("desaturated");
    }
    else if (document.getElementById("secondary")) {
        parentId = document.getElementById("secondary");
    }
    else if (document.getElementById("success")) {
        parentId = document.getElementById("success");
    }
    else if (document.getElementById("error")) {
        parentId = document.getElementById("error");
    }
    else if (document.getElementById("info")) {
        parentId = document.getElementById("info");
    }
    else if (document.getElementById("warning")) {
        parentId = document.getElementById("warning");
    }
    return parentId
}

