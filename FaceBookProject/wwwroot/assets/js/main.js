let faceMenuListItems = document.querySelectorAll('.facemenu-list-item > a');
let friends = document.querySelectorAll('#friends li a.option');
let users = document.querySelectorAll('#sendSuggest');
let accepts = document.querySelectorAll('#accept'); 
let regrets = document.querySelectorAll('#regret');
let body = document.querySelectorAll('body');
let emojiBox = document.querySelector('.chat-footer .emoji-container');
//let message = document.querySelector('.chat-footer .textarea span');



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

    // Send Suggest    
    users.forEach(user => {        
        $(user).on('click', function () {
            let userId = user.getAttribute('data-id');
            let parent = user.parentElement;
            user.remove();
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

    friends.forEach(friend => {
        $(friend).on('click', function () {
            if ($('.chat')) {
                $('.chat').remove();
            }
            let userId = friend.getAttribute('data-id');
            //let parent = user.parentElement;
            //user.remove();
            $.ajax({
                url: `/Home/OpenFriendWindow?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(body).append(response);
                }
            });

        });
    });
});


//It works after ajax complete
$(document).ajaxComplete(function () {
    let chat = document.querySelector('.chat');
    let closeBtn = document.querySelector('.chat-header #close');
    let message = document.querySelector('.chat-footer .textarea span');
    let sendbtn = document.querySelector('#send');
    let chatBody = document.querySelector('.chat-body');
    let emoji = document.querySelector('.chat-footer #emoji');


      message.addEventListener('focus', function(params) {       
        //Send Message when user press Enter button at message input's onfocus     
        message.onkeypress = function(event) {
                 if (event.keyCode === 13) {
                event.preventDefault();
                     let userId = sendbtn.getAttribute('data-id');
                     let text = message.textContent;

                     if (message.textContent.length != 0) {
                         $.ajax({
                             url: `/Home/SendMessage?id=${userId}&message=${text}`,
                             type: "Get",
                             success: function (response) {
                                 message.textContent = null;
                                 $(chatBody).append(response);
                             }
                         });
                     }
            }        
        }     
    });

     //Send Message when click send button
     sendbtn.addEventListener('click', function(params) {
        params.preventDefault();
         let userId = sendbtn.getAttribute('data-id');
         let text = message.textContent;
        

         if (message.textContent.length != 0) {
             $.ajax({
                 url: `/Home/SendMessage?id=${userId}&message=${text}`,
                 type: "Get",
                 success: function (response) {
                     message.textContent = null;
                     $(chatBody).append(response);
                 }
             });            
        }     
    });
     
    closeBtn.addEventListener('click', function (event) {
        event.preventDefault();
        chat.remove();
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


    //Function that Create emoji list 
    function CreateEmojiList() {
        let emojiList = document.createElement('ul');
        emojiList.classList.add('emoji-container');
        
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

});