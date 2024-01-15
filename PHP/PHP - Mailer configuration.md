# PHP MAILER CONFIGURATION
#PHP 

## INTRODUCTION 

Documentation about how to send emails in PHP using the PHPMailer library (COMPOSER) via Gmail SMTP.  
PHPMailer is a tool in the Email API category of a tech stack. PHPMailer is more popular than simple email since it provides more capabilities such as attachments, encryption, authentication, and so on. It also streamlines the process of sending HTML emails.

## GOOGLE CONFIGURATION 

Before sending emails using Gmail's SMTP Server, you can make some security and permission level settings under your Google Account Security Settings.
1.   Open your Gmail account settings. Click on Sign-in and Security. Post that, navigate to connected apps and sites, and now enable two-factor authentication. 
2.   Create an app password. The app password should be the password you use in your SMTP settings. You can generate an app password by visiting this page while logged into your Google account.
3.   Turn ON the "Less Secure App" access or click here. (This wont be avaliable if two factor authentication is enabled)

---
## BASIC USAGE

#### INSTALLATION IN PROJECT 

You can install the PHPMailer via composer. With this package manager, just navigate into directory of the project and: 

```BASH
	composer require phpmailer/phpmailer
```

#### INITIALIZATION

For being able to use Goole smtp service to send email using your Gmail credentials, You just need to connect to host "smtp.gmail.com". 

<span style="color:orange;">Step 1</span> Initializate the library
```php 
	use PHPMailer\PHPMailer\PHPMailer;
	use PHPMailer\PHPMailer\Exception;
	require 'PHPMailer-master/src/Exception.php';
	require 'PHPMailer-master/src/PHPMailer.php';
	require 'PHPMailer-master/src/SMTP.php';
```
<span style="color:orange;">Step 2</span>  Initializate PHP Mailer and smtp connection
```php
	$mail = new PHPMailer(true);  // Initializate the PHP Mailer
	$mail->IsSMTP(); 
	$mail->Mailer = "smtp";
```

<span style="color:orange;">Step 3</span> Basic requirements  for being able to send an email. 

```php 
	$mail->SMTPDebug  = 1;  		// Set the debug on to show errors
	$mail->SMTPAuth   = TRUE;
	$mail->SMTPSecure = "tls";
	$mail->Port       = 587;
	$mail->Host       = "smtp.gmail.com";
	$mail->Username   = "your-email@gmail.com";
	$mail->Password   = "your-gmail-password";
```
If you want to not recieve debug information, just comment or delete the <span style="color:#abcdf5;">$mail->SMTPDebug</span> to make the verbose to default  = noone. 

### HOW TO SEND AN EMAIL 


Firstly, before sending the email, the email parameters need to be setted. 

```php
	$mail->IsHTML(true);
	$mail->AddAddress("recipient-email@domain", "recipient-name");
	$mail->SetFrom("from-email@gmail.com", "from-name");
	$mail->AddReplyTo("reply-to-email@domain", "reply-to-name");
	$mail->AddCC("cc-recipient-email@domain", "cc-recipient-name");
	$mail->Subject = "Test is Test Email sent via Gmail SMTP Server using PHP Mailer";
	$content = "<b>This is a Test Email sent via Gmail SMTP Server using PHP mailer class.</b>";
```

And after that, send the email controlling the posible exceptions or error that may occur. 

```php
	$mail->MsgHTML($content); 
	if(!$mail->Send()) {
	  echo "Error while sending Email.";
	  var_dump($mail);
	} else {
	  echo "Email sent successfully";
	}
```

--- 
#### TAKE ON ACCOUNT 

#### Debug mode 

To enable debbuging in PHP Mailer, needs set this flag to **1**. 
```php 
	$mail->SMTPDebug  = 1; 
```

To disable debug mode, just erase `$mail->SMTPDebug  = 1;` declaration 


--- 