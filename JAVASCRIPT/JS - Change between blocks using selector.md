#JS 

You can change the displayed section of code and switch between them using Javascript for the responsive and HTML for the structure. 

Firstly to be able to select between the blocks, one common way is to use an HTML form `<select>` tag with a few `<options>`. The option selected can be read from Javascript and change the sections accordingly. 

This <span style="color:cyan;">option selector</span> have a `change` callback, that we can assign a function that change the section when there is a change in the option selected by the `selector`. 

Once you have make some sections inside a `<div>` with a unique id, you can make a javascript file that select the different sections using  <span style="color:orange;">query selectors</span> [[JS - document]] and by changing its css style display property from `none` to `block` can be pass from `invisible` to `visible`. 


Example of changing between payment methods in a webpage using a selector with 3 options: 
* Credit card
* Paypal 
* Cryptocurrency

```HTML
<div class="checkout-main-payment-section">  
                <label for="paymentMethod">Select Payment Method:</label>  
                <select id="paymentMethod">  
                    <option value="creditCard">Credit Card</option>  
                    <option value="paypal">PayPal</option>  
                    <option value="cryptocurrency">Cryptocurrency</option>  
                </select>  
                <div class="checkout-main-payment-section-details">  
                <!-- Credit Card Details -->  
                    <div id="creditCardDetails" >  
                        <label for="creditCardNumber">Credit Card Number:   
                        <input type="text" id="creditCardNumber" placeholder="Enter your credit card number" required></label>  
                          
                        <label for="expiryDate">Expiry Date:  
                        <input type="text" id="expiryDate" placeholder="MM/YYYY" maxlength="7" required></label>  
  
                        <label for="cvv">CVV:  
                        <input type="text" id="cvv" placeholder="Enter CVV" maxlength="3" required></label>  
                    </div>  
                    <!-- PayPal Details -->  
                    <div id="paypalDetails" style="display: none;">  
                        <label for="paypalEmail">PayPal Email:</label>  
                        <input type="text" id="paypalEmail" placeholder="Enter your PayPal email">  
                    </div>  
                    <!-- Cryptocurrency Details -->  
                    <div id="cryptoDetails" style="display: none;">  
                    <label for="cryptoType">Select Cryptocurrency:</label>  
                    <select id="cryptoType">  
                        <option value="bitcoin">Bitcoin</option>  
                        <option value="ethereum">Ethereum</option>  
                        <option value="litecoin">Litecoin</option>  
                    </select>                    </div>                    <button id="checkout-button" type="button">Checkout</button>  
                </div>            </div><!-- ------------------------SCRIPTS SECTION ------------------------>  
<script>  
	document.getElementById('paymentMethod').addEventListener('change', function() {  

		let creditCardDetails = document.getElementById('creditCardDetails');  
		let paypalDetails = document.getElementById('paypalDetails');  
		let cryptoDetails = document.getElementById('cryptoDetails');  

		creditCardDetails.style.display = 'none';  
		paypalDetails.style.display = 'none';  
		cryptoDetails.style.display = 'none';  

		let selectedPaymentMethod = this.value;  

		if (selectedPaymentMethod === 'creditCard') {  
			creditCardDetails.style.display = 'block';  
		}  
		else if (selectedPaymentMethod === 'paypal') {  
			paypalDetails.style.display = 'block';  
		}  
		else if (selectedPaymentMethod === 'cryptocurrency') {  
			cryptoDetails.style.display = 'block';  
		}  
	});  
</script>
```