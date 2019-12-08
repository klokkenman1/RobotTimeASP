var exercises;
var currentExercise = 0;
var robot = false;
var startTime;
var id;
var _choice;

$(function () {
    FastClick.attach(document.body);
});

function startSubscribe(choice) {
    _choice = choice;
    $("#info").css('display', 'block');
    $("#choices").css('display', 'none');

    fetch("https://robottime.azurewebsites.net/api/exercises", {
        method: 'GET',
        ContentType: 'application/json'
    })
        .then(function (resp) { return resp.json() })
        .then(function (data) {
            exercises = data
            $("#spinner").css('display', 'none');
            $("#name").text(exercises[currentExercise].name);
            $("#timer").text(exercises[currentExercise].time);

            if (_choice == 'b')
                $("#image").attr("src", exercises[currentExercise].mUrl);
            else
                $("#image").attr("src", exercises[currentExercise].fUrl);

            startTime = exercises[currentExercise].time;
            if (robot)
                RobotUtils.onServices(function (ALMemory) {
                    ALMemory.subscriber("PepperQiMessaging/start").then(function (subscriber) {
                        subscriber.signal.connect(function () {
                            $("#start").css('display', 'block')
                        }).then(function () {
                            ALMemory.raiseEvent("PepperQiMessaging/loaded", 1);
                        });
                    });
                    ALMemory.subscriber("PepperQiMessaging/next").then(function (subscriber) {
                        subscriber.signal.connect(function () {
                            $("#pause").css('display', 'none');
                            $("#next").css('display', 'block');
                        })
                    });
                });
            else {
                $("#start").css('display', 'block');
            }
        });
}



function sendToChoregraphe(event, state) {
    if (robot)
        RobotUtils.onServices(function (ALMemory) {
            console.log("ALMemory");
            ALMemory.raiseEvent("PepperQiMessaging/" + event, state);
        });
}


function start() {
    sendToChoregraphe("animation", exercises[currentExercise].id)
    id = setInterval(timer, 1000);
    $("#start").css('display', 'none');
    $("#pause").css('display', 'block');
    sendToChoregraphe("state", 1)
};

function timer() {
    if (startTime >= 0) {
        $('#timer').text(startTime--);
    }
    else {
        //Finish
        clearInterval(id);
        $("#pause").css('display', 'none');
        sendToChoregraphe("state", 2);
    }
}

function pause() {
    clearInterval(id);
    sendToChoregraphe("state", 0);
    $("#start").css('display', 'block');
    $("#pause").css('display', 'none');
}

function next() {
    sendToChoregraphe("state", 3);
    if (++currentExercise >= exercises.length) {
        $("#name").text("Einde");
        $("#timer").text("");
        $("#image").attr("src", "");
        $("#next").css('display', 'none');
    }
    else {
        $("#name").text(exercises[currentExercise].name);
        $("#timer").text(exercises[currentExercise].time);
        if (_choice == 'b')
            $("#image").attr("src", exercises[currentExercise].mUrl);
        else
            $("#image").attr("src", exercises[currentExercise].fUrl);
        startTime = exercises[currentExercise].time;
        $("#start").css('display', 'block');
        $("#next").css('display', 'none');
    }

}