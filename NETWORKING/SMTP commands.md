#NETWORKING 

### SEND EMAIL


1. Enter `HELO <your_domain_name>` and press Return.  
2. Enter `AUTH LOGIN` and press Return.  
3. Now you need to enter the Base64 version of your email address without making any mistakes. Press Return.  
4. Enter the Base64 version of your password and press Return.

Hopefully, you will see the message: **235 Authentication succeeded**.

5. Enter `MAIL FROM:<your_email_address>` and press Return.

You should see the message: **250 OK**.

6. Enter `RCPT TO:<destination_email_address>` and press Return.

You will see the message: **250 Accepted**.

7. Enter `DATA`and press Return.  
8. Enter `Subject: Test` (mail subject) and press Return.  It should not return nothing. 
9. Enter `Test message` (mail body)and press Return.  
10. Enter `.`  and press Return.

This will return:  ```250 2.0.0 Ok: queued as 8CD30301D13```

### CHECK MAILS

1.  Enter the `telnet localhost 1110` to connect via POP3. 
2. login using `USER <user> PASS <pass>`. 
3. 
