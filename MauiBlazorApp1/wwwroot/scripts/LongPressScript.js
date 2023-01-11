function changeIcons(Bulk) {

   
    var ItemID = document.getElementById('change-item')
    var parentID = ItemID.parentNode
 

    if (Bulk === 'longpress') {
        var parentOfParent = parentID.parentNode
        parentOfParent.removeChild(parentID);

        var item = document.createElement("span");
        item.id = 'change-item'
        item.classList.add('oi');
        item.classList.add('oi-menu');

        parentOfParent.appendChild(item);
    }
    else if (Bulk === 'close')
    {
        var parentOfParent = parentID
        parentOfParent.removeChild(ItemID);


        const newLabel = document.createElement("label");
        newLabel.setAttribute("for", 'change-item');
      

        var item = document.createElement("input");
        item.setAttribute("type", 'checkbox');
        item.classList.add('e-control');
        item.classList.add('e-checkbox');
        item.classList.add('e-lib');
        item.id = 'change-item'


        var checkbox = document.createElement("span");
        checkbox.classList.add('e-icons');
        checkbox.classList.add('e-frame');
        checkbox.classList.add('e-check');
    
        var newSpan = document.createElement("span");
        checkbox.classList.add('e-label');

        newLabel.appendChild(checkbox)
        newLabel.appendChild(item)
        newLabel.appendChild(newSpan)
        parentOfParent.appendChild(newLabel);
    }
 
}