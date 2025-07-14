$(document).ready(function () {


    const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7192/carhub")
        .configureLogging(signalR.LogLevel.Information)
        .build();



    const currentUserIdForMessage = parseInt(document.getElementById("currentUserId").value);
    const otherUserIdForMessage = parseInt(document.getElementById("otherUserId").value);



    async function start() {

        try {

            await connection.start().then(() => {
                $("#connectionId").html(`connectionId : ${connection.connectionId}`);
                console.log("hub ile bağlantı kuruldu Message Hub")
            });

        }
        catch (err) {
            console.error("hub ile bağlantı kurulamadı", err);
            setTimeout(() => start(), 3000);
        }

    }

    connection.onclose(async () => {
        await start(); // bağlantı yeniden kurulana kadar bekliyorum aslında ben burda
    });

    start();

    connection.on("getUpdatedMessages", (messages,senderId,receiverId) => {

       

        if ((currentUserIdForMessage == senderId && otherUserIdForMessage == receiverId) || (currentUserIdForMessage == receiverId && otherUserIdForMessage == senderId)) {



            const messagesDiv = document.querySelector('.messages');
            messagesDiv.innerHTML = ""; // önce mevcut mesajları temizle

            messages.forEach(msg => {

                const messageDiv = document.createElement('div');
                messageDiv.classList.add('message');

                const senderIdValue = parseInt(msg.senderID);
               

                if (senderIdValue === currentUserIdForMessage) {
                    messageDiv.classList.add('sent');
                } else {
                    messageDiv.classList.add('received');
                }

                messageDiv.innerHTML = `
                <div class="message-content">
                    <p>${msg.content}</p>
                    <span class="message-time">${msg.createdDate.slice(11, 16)}</span>
                </div>
                `;

                messagesDiv.appendChild(messageDiv);
            });


            document.getElementById("replyMessageContent").value = "";
            
            









        }



    });




    $("#btn-send-message").click(function () {



        if (currentUserIdForMessage == 0) {
            window.location.href = "/Login/Index";
            return;
        }

        const messageContent = document.getElementById("replyMessageContent").value;


        connection.invoke("AddAndUpdateMessage", currentUserIdForMessage, otherUserIdForMessage, messageContent).catch(function (err) {
            console.error(err.toString());
        });


    })





})