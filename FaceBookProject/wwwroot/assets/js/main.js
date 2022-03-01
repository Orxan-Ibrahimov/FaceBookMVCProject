let faceMenuListItems = document.querySelectorAll('.facemenu-list-item > a');
let friends = document.querySelectorAll('#friends li a.option');
let allFriends = document.querySelectorAll('#openChat');
let users = document.querySelectorAll('#sendSuggest');
let accepts = document.querySelectorAll('#accept'); 
let regrets = document.querySelectorAll('#regret');
let body = document.querySelectorAll('body'); 
let emojiBox = document.querySelector('.chat-footer .emoji-container'); 
let operations = document.querySelectorAll('.modal-operations');
let profileOperations = document.querySelectorAll('.profile-operations');
let coverOperations = document.querySelectorAll('.cover-operations');
let exampleModal = document.querySelector('#exampleModal');
let profileImage = document.querySelector('#profileImage'); 
let coverImage = document.querySelector('#coverImage');
let about = document.querySelector('#about');
let orxan = document.querySelector('#orxan'); 
let container = document.querySelector('#orxan .container');
let StoryWindowBtns = document.querySelectorAll('.openStoryWindow'); 
let storyBox = document.querySelector('#storyBox');
let addEmoji = document.querySelector('#addEmoji'); 
let storyMessage = document.querySelector('#storyBox textarea');
let emotions = document.querySelector('#emotions'); 
let emotionOpen = document.querySelectorAll('.emotion-open'); 
let howFeel = document.querySelector('#howFeel');
let feelingBtns = document.querySelectorAll('.feelingBtn');
//let message = document.querySelector('.chat-footer .textarea span');



window.addEventListener('load', function (params) {
    // submenu's open/close operation at faceMenulist
    faceMenuListItems.forEach(faceMenuListItem => {
        faceMenuListItem.addEventListener('click', function (params) {
            $(faceMenuListItems).each(function (index, element) {
                element.parentElement.classList.remove('active');
            });
            let subfacemenu = faceMenuListItem.nextElementSibling;
            if (subfacemenu?.style.display != 'block')
                subfacemenu.style.display = 'block';
            else
                subfacemenu.style.display = 'none';
        });
    });

    // Send Suggest    
    users.forEach(user => {
        user.onclick = function (params) {
            params.preventDefault();
            let userId = user.getAttribute('data-id');
            let parent = user.parentElement;
            user.remove();
            console.log(user);
            $.ajax({
                url: `/Home/SendSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(parent).append(response);
                }
            });

        };
    });

    // Accept Suggest    
    accepts.forEach(accept => {
        accept.onclick = function () {
            let userId = accept.getAttribute('data-id');
            let parent = accept.parentElement;
            let childs = parent.childNodes;

            $(childs).each(function (index, child) {
                child.remove();
            });

            const myTimeout = setTimeout(RemoveList, 2000);

            function RemoveList() {
                let suggests = parent.parentElement.parentElement.parentElement.parentElement;
                if (suggests.parentElement.getAttribute('id') == "suggests") {
                    suggests.remove();
                }
            }

            let p = document.createElement('p');
            p.textContent = "Teklifi kabul ettiniz";
            p.classList.add('text-success');
            p.classList.add('fw-bold');
            parent.append(p);

            $.ajax({
                url: `/Home/AcceptSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {                  
                    $('#friends').append(response);
                }
            });

        }
    });
    
    // Regret Suggest    
    regrets.forEach(regret => {
        regret.onclick = function () {
            let userId = regret.getAttribute('data-id');
            let parent = regret.parentElement;
            let childs = parent.childNodes;
            $(childs).each(function (index, child) {
                child.remove();
            });
            const myTimeout = setTimeout(RemoveList, 2000);

            function RemoveList() {
                let suggests = parent.parentElement.parentElement.parentElement.parentElement;
                if (suggests.parentElement.getAttribute('id') == "suggests") {
                    suggests.remove();
                }
            }


            $.ajax({
                url: `/Home/RegretSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(parent).append(response);
                }
            });

        }
    });

    allFriends.forEach(friend => {
        friend.onclick = function () {
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

        }
    });
 
    $(operations).each(function (index, element) {
        $(element).on('click', function () {
            $(exampleModal).toggle("slow", "linear");
        });
    });

    $(profileOperations).each(function (index, element) {
        $(element).on('click', function () {
            $(profileImage).slideToggle("slow", "linear");
        });
    });

    $(coverOperations).each(function (index, element) {
        $(element).on('click', function () {
            $(coverImage).slideToggle("slow", "linear");
        });
    });

    //about
    $(about).on('click', function () {
        let userId = about.getAttribute('data-id');
        about.parentElement.classList.add('active');
        //about.preventDefault();
        $(container).remove();

        $.ajax({
            url: `/Profile/ProfileAbout?id=${userId}`,
            type: "Get",
            success: function (response) {
                $(orxan).append(response);
            }
        });
    });

    $(StoryWindowBtns).each(function (index, element) {
        $(element).unbind().on('click', function (params) {
            $(storyBox).slideToggle("slow", "linear");
        });
    });  

    addEmoji.onclick = function (event) {
        event.preventDefault();

        let emojiList = CreateEmojiList(storyMessage);
        if (addEmoji.parentElement.querySelector('.emoji-container') == null)
            addEmoji.parentElement.appendChild(emojiList);
        else
            addEmoji.parentElement.querySelector('.emoji-container').remove();
    };

    $(emotionOpen).each(function (index, element) {        
        $(element).on('click', function (params) {
            params.preventDefault();

            $(storyBox).slideToggle("slow", "linear");
            $(emotions).slideToggle("slow", "linear");
        });
    });

    $(feelingBtns).each(function (index, element) {
        $(element).on('click', function (params) {
            params.preventDefault();
            /*$(element).parent().remove();*/

            $('#howFeel *').each(function (index, element) {
                $(element).remove()
            });


            console.log($(element).parent())
            $(storyBox).slideToggle("slow", "linear");
            $(emotions).slideToggle("slow", "linear");

            let userId = element.getAttribute('data-id');
            
            $.ajax({
                url: `/Home/AddEmotion?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(howFeel).append(response);
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
    let users = document.querySelectorAll('#sendSuggest');
    let allFriendsAtProfile = document.querySelector('#allFriends');
    let allFriendItems = document.querySelectorAll('#allFriends li');
    let mutualFriendsLink = document.querySelector('#mutual-friends a');
    let allFriends = document.querySelectorAll('#openChat');


    $(mutualFriendsLink).on('click', function () {
        let userId = mutualFriendsLink.getAttribute('data-id');

        $(allFriendItems).each(function (index, element) {
            $(element).remove();
        });
        $.ajax({
            url: `/Profile/MutualFriends?id=${userId}`,
            type: "Get",
            success: function (response) {
                $(allFriendsAtProfile).append(response);
            }
        });
    });

    // Send Suggest    
    users.forEach(user => {
        user.onclick = function (params) {
            params.preventDefault();
            let userId = user.getAttribute('data-id');
            let parent = user.parentElement;
            user.remove();
            console.log(user);
            $.ajax({
                url: `/Home/SendSuggest?id=${userId}`,
                type: "Get",
                success: function (response) {
                    $(parent).append(response);
                }
            });

        };
    });

    message.addEventListener('focus', function (params) {
        //Send Message when user press Enter button at message input's onfocus     
        message.onkeypress = function (event) {
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

    allFriends.forEach(friend => {
        friend.onclick = function () {
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

        }
    });

    //Send Message when click send button
    sendbtn.onclick = function (params) {
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
    };

    closeBtn.addEventListener('click', function (event) {
        event.preventDefault();
        chat.remove();
    });

    //emoji list Crete/remove operation
    emoji.onclick = function (event) {
        event.preventDefault();

        let emojiList = CreateEmojiList(message);
        if (emoji.parentElement.querySelector('.emoji-container') == null)
            emoji.parentElement.appendChild(emojiList);
        else
            emoji.parentElement.querySelector('.emoji-container').remove();
    };


});

//Function that Create emoji list 
function CreateEmojiList(message) {
    let emojiList = document.createElement('ul');
    emojiList.classList.add('emoji-container');
    emojiList.classList.add('scroll-appeareance');

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
            if ($(message).hasClass('isTextarea')) {
                message.value += emojiSpan.textContent;
            }
            else {
                message.textContent += emojiSpan.textContent;
            }
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
            if ($(message).hasClass('isTextarea')) {
                message.value += emojiSpan.textContent;
            }
            else {
                message.textContent += emojiSpan.textContent;
            }
        });
    }

    return emojiList;

}