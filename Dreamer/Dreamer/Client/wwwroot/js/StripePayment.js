redirectToCheckout = function (sessionId) {
    var stripe = Stripe('pk_test_51JnmqMAhRXVR99JP9bkeQrCqixFy8SrCsg6q49O893xjfOwfqavcHRkpxlRnwgsxmLmzw5jmSwJCEOYVXAbI4Lul00h1f9AXg1');
    stripe.redirectToCheckout({
        sessionId: sessionId
    });
};
