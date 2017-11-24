# Rule-Design-Pattern
Implementing Rule Design Pattern with card payment example

Summary

This is a demonstration on how we can use Rule Design pattern to validate a payment dynamically by different rules. This example implenents a service contract which has 2 operations as below:

    WhatsYourId: 008ab27c-36b2-43e5-91d5-edbd1e5b564b. This operation should return the unique ID poiting to a Merchant Identification Number.

    MakePayment: should validate the card and amount and return a Guid if successful and null if information is not valid

Business rule

    IsCardNumberValid: Implement the MOD10 algorithm as explained here: https://en.wikipedia.org/wiki/Luhn_algorithm. Include a validation for the number of digits in the card number to ensure 16 digits are passed.

    IsValidPaymentAmount: Check if the passed number is a valid number between 99 and 99999999.

    CanMakePaymentWithCard: Evaluate the parameters passed to ensure they represent a valid card that can be

used to make payments:

    cardNumber: is a valid 16 digit number that passes the MOD10 check as explained in 2 above

    expiryMonth: should represent a month number between 1 and 12

    expiryYear: Should represent a year value, 4 characters in lenght and either the current or a future year

    The expiry month + year should represent a date in the future
