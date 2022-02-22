let faceMenuListItems = document.querySelectorAll('.facemenu-list-item > a');
let chatBody = document.querySelector('.chat-body');
let chat = document.querySelector('.chat');
let message = document.querySelector('.chat-footer .textarea span');
let emojiBox = document.querySelector('.chat-footer .emoji-container');
let emoji = document.querySelector('.chat-footer #emoji');
let closeBtn = document.querySelector('.chat-header #close');
let sendbtn = document.querySelector('#send');
let friends = document.querySelectorAll('#friends li a.option');
let users = document.querySelectorAll('#sendSuggest');
let accepts = document.querySelectorAll('#accept');
let regrets = document.querySelectorAll('#regret');


window.addEventListener('load', function (params) {


    // submenu's open/close operation at faceMenulist
    faceMenuListItems.forEach(faceMenuListItem => {
        faceMenuListItem.addEventListener('click', function (params) {
            let subfacemenu = faceMenuListItem.nextElementSibling;
            if (subfacemenu.style.display != 'block')
                subfacemenu.style.display = 'block';
            else
                subfacemenu.style.display = 'none';
        });
    });

     //Send Message when click send button
     sendbtn.addEventListener('click', function(params) {
        params.preventDefault();
        
        if (message.textContent.length != 0){
            let chatMessage = CreateButon(message);
            chatBody.appendChild(chatMessage);

        }     

    });

    message.addEventListener('focus', function(params) {       
        //Send Message when user press Enter button at message input's onfocus     
        message.onkeypress = function(event) {
                 if (event.keyCode === 13) {
                event.preventDefault();

                if (message.textContent.length != 0){
                    let chatMessage = CreateButon(message);
                    chatBody.appendChild(chatMessage);

                }                            
            }        
        }     
    });

    //emoji list Crete/remove operation
    emoji.addEventListener('click', function (event) {
        event.preventDefault();

        let emojiList = CreateEmojiList();
        if (emoji.parentElement.querySelector('.emoji-container') == null)
            emoji.parentElement.appendChild(emojiList);
        else
            emoji.parentElement.querySelector('.emoji-container').remove();
    });

    friends.forEach(friend => {
        friend.addEventListener('click', function(event) {
            event.preventDefault();
            chat.style.display = "block";
    
        });
    });
   

    closeBtn.addEventListener('click', function(event) {
        event.preventDefault();
        chat.style.display = 'none';
    });

    // Send Suggest    
    users.forEach(user => {        
        $(user).on('click', function () {
            let userId = user.getAttribute('data-id');
            let parent = user.parentElement;
            user.remove();
            console.log(parent);
            $.ajax({
                url: `/Home/SendSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(parent).append(response);                    
                }
            });

        });
    });

    // Accept Suggest    
    accepts.forEach(accept => {
        $(accept).on('click', function () {
            let userId = accept.getAttribute('data-id');
            //let parent = user.parentElement;
            //user.remove();
            //console.log(parent);
            $.ajax({
                url: `/Home/AcceptSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(parent).append(response);
                }
            });

        });
    });

    // Regret Suggest    
    regrets.forEach(regret => {
        $(regret).on('click', function () {
            let userId = regret.getAttribute('data-id');
            //let parent = user.parentElement;
            //user.remove();
            //console.log(parent);
            $.ajax({
                url: `/Home/RegretSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(parent).append(response);
                }
            });

        });
    });
});

// Function that Create message element in chat 
function CreateButon(input) {
    let messageBox = document.createElement('div');
    messageBox.classList.add('message-sent');

    let message = document.createElement('p');
    message.classList.add('message');
    //message.innerHTML = input.textContent;
    message.textContent = input.textContent;

    messageBox.appendChild(message);
    input.textContent = null;

    return messageBox;
}

//Function that Create emoji list 
function CreateEmojiList() {
    let emojiList = document.createElement('ul');
    emojiList.classList.add('emoji-container');
    // 128512
    // 128568
    
    let emoliListItem = document.createElement('li');
    emoliListItem.classList.add('w-100');
    emojiList.appendChild(emoliListItem);

    let p = document.createElement('p');
    p.classList.add('text-muted');
    p.classList.add('small');
    p.classList.add('fw-bold');
    p.classList.add('mx-2');
    p.textContent = 'Gülen Yüzler ve İnsanlar';
    emoliListItem.appendChild(p);

    for (let index = 128512; index < 128591; index++) {
        let emoliListItem = document.createElement('li');
        emojiList.appendChild(emoliListItem);

        let emojiLink = document.createElement('a');
        emoliListItem.appendChild(emojiLink);

        let emojiSpan = document.createElement('span');
        emojiSpan.innerHTML = '&#' + index;
        emojiLink.appendChild(emojiSpan);

        emojiLink.addEventListener('click', function (params) {
        message.textContent += emojiSpan.textContent;
        });        
    }

    for (let index = 128064; index < 128170; index++) {
        let emoliListItem = document.createElement('li');
        emojiList.appendChild(emoliListItem);

        let emojiLink = document.createElement('a');
        emoliListItem.appendChild(emojiLink);

        let emojiSpan = document.createElement('span');
        emojiSpan.innerHTML = '&#' + index;
        emojiLink.appendChild(emojiSpan);

        emojiLink.addEventListener('click', function (params) {
        message.textContent += emojiSpan.textContent;
        });
}

    return emojiList;

}