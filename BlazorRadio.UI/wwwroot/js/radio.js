$(document).ready(function () {

    $('#app').on('click', '#playpause', function () {
        var stationid = $(this).data('stationid');
        var iconControl = $('#' + stationid + ' #icon');
        var progressControl = $('#' + stationid + ' #radioProgress');
        var audioControl = $('#' + stationid + ' audio');

        if ($(iconControl).data('playing') == 'false') {
            $(iconControl).removeClass('fa-play');
            $(iconControl).addClass('fa-pause');
            $(progressControl).addClass('progress-bar-animated');
            $(iconControl).data('playing', 'true');
            $(audioControl)[0].play();
        }
        else {
            $(iconControl).removeClass('fa-pause');
            $(iconControl).addClass('fa-play');
            $(progressControl).removeClass('progress-bar-animated');
            $(iconControl).data('playing', 'false');
            $(audioControl)[0].pause();
        }
    });

    $('#app').on('click', '.menu-button', function () {
        var toggleWidth = $(".playlist").width() == 0 ? "100%" : "0";
        $('.playlist').animate({ width: toggleWidth });
    });

    $('#app').on('click', '.play', function () {
        PlayStation();
    });

    $('#app').on('click', '.pause', function () {
        $("#playStatus").text("");
        $('#audio')[0].pause();
        $('.fa-play').css('display', 'block');
        $('.fa-pause').css('display', 'none');
    });

});

function EnableSlider() {

    $("#volumebar").slider({
        min: 0,
        max: 100,
        value: 50,
        range: "min",
        slide: function (event, ui) {
            SetAudioVolume((ui.value / 100));
        }
    });
}

function HidePlayList() {
    var toggleWidth = $(".playlist").width() == 0 ? "100%" : "0";
    $('.playlist').animate({ width: toggleWidth });
}

function PlayStation() {

    setTimeout(function () {
        var playPromise = $('#audio')[0].play();
        $("#playStatus").text("Connecting to station...");
        $('.connecting').css('display', 'block');
        $('.fa-play').css('display', 'none');
        $('.fa-pause').css('display', 'none');
        if (playPromise !== undefined) {
            playPromise.then(_ => {
                $("#playStatus").text("Playing...");
                $('.fa-play').css('display', 'none');
                $('.fa-pause').css('display', 'block');
                $('.connecting').css('display', 'none');
            })
                .catch(error => {
                    $("#playStatus").text("Failed Connecting to station...");
                    $('.fa-play').css('display', 'block');
                    $('.fa-pause').css('display', 'none');
                    $('.connecting').css('display', 'none');
                });
        }
    }, 500);
}

function SetAudioVolume(volumeLevel) {
    var audio = $('#audio')[0];
    audio.volume = volumeLevel;
}

function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

/* Set the width of the side navigation to 0 */
function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}