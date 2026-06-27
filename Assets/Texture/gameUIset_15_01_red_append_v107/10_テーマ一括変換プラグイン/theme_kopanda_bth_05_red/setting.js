// システムボタン専用のhoverアニメ
// role_button_blink のアニメ定義は bth06_anim.css 参照
$(document).on("mouseenter", ".role_button", function() {
  $(this).css("transform", "scale(1.03)");
  $(this).addClass("role_button_blink");
});

$(document).on("mouseleave", ".role_button", function() {
  $(this).css("transform", "scale(1)");
  $(this).removeClass("role_button_blink");
});
