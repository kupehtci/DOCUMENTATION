#PHP 


This is a list of the possible <span style="color:orange;">Filter types</span> that can be used with `filter_var()` function. 

### VALIDATION FILTERS

|ID|Name|Options|Flags|Description|
|---|---|---|---|---|
|**`FILTER_VALIDATE_BOOLEAN`**,**`FILTER_VALIDATE_BOOL`**|"boolean"|`default`|**`FILTER_NULL_ON_FAILURE`**|Returns **`true`** for "1", "true", "on" and "yes". Returns **`false`** otherwise.<br><br>If **`FILTER_NULL_ON_FAILURE`** is set, **`false`** is returned only for "0", "false", "off", "no", and "", and **`null`**is returned for all non-boolean values.<br><br>String values are trimmed using [trim()](https://www.php.net/manual/en/function.trim.php) before comparison.|
|**`FILTER_VALIDATE_DOMAIN`**|"validate_domain"|`default`|**`FILTER_FLAG_HOSTNAME`**,**`FILTER_NULL_ON_FAILURE`**|Validates whether the domain name label lengths are valid.<br><br>Validates domain names against RFC 1034, RFC 1035, RFC 952, RFC 1123, RFC 2732, RFC 2181, and RFC 1123. Optional flag**`FILTER_FLAG_HOSTNAME`** adds ability to specifically validate hostnames (they must start with an alphanumeric character and contain only alphanumerics or hyphens).|
|**`FILTER_VALIDATE_EMAIL`**|"validate_email"|`default`|**`FILTER_FLAG_EMAIL_UNICODE`**,**`FILTER_NULL_ON_FAILURE`**|Validates whether the value is a valid e-mail address.<br><br>In general, this validates e-mail addresses against the `addr-spec`syntax in [» RFC 822](http://www.faqs.org/rfcs/rfc822), with the exceptions that comments and whitespace folding and dotless domain names are not supported.|
|**`FILTER_VALIDATE_FLOAT`**|"float"|`default`,`decimal`,`min_range`,`max_range`|**`FILTER_FLAG_ALLOW_THOUSAND`**,**`FILTER_NULL_ON_FAILURE`**|Validates value as float, optionally from the specified range, and converts to float on success.<br><br>String values are trimmed using [trim()](https://www.php.net/manual/en/function.trim.php) before comparison.|
|**`FILTER_VALIDATE_INT`**|"int"|`default`,`min_range`,`max_range`|**`FILTER_FLAG_ALLOW_OCTAL`**,**`FILTER_FLAG_ALLOW_HEX`**,**`FILTER_NULL_ON_FAILURE`**|Validates value as integer, optionally from the specified range, and converts to int on success.<br><br>String values are trimmed using [trim()](https://www.php.net/manual/en/function.trim.php) before comparison.|
|**`FILTER_VALIDATE_IP`**|"validate_ip"|`default`|**`FILTER_FLAG_IPV4`**,**`FILTER_FLAG_IPV6`**,**`FILTER_FLAG_NO_PRIV_RANGE`**,**`FILTER_FLAG_NO_RES_RANGE`**,**`FILTER_FLAG_GLOBAL_RANGE`**,**`FILTER_NULL_ON_FAILURE`**|Validates value as IP address, optionally only IPv4 or IPv6 or not from private or reserved ranges.|
|**`FILTER_VALIDATE_MAC`**|"validate_mac_address"|`default`|**`FILTER_NULL_ON_FAILURE`**|Validates value as MAC address.|
|**`FILTER_VALIDATE_REGEXP`**|"validate_regexp"|`default`,`regexp`|**`FILTER_NULL_ON_FAILURE`**|Validates value against `regexp`, a[Perl-compatible](https://www.php.net/manual/en/book.pcre.php) regular expression.|
|**`FILTER_VALIDATE_URL`**|"validate_url"|`default`|**`FILTER_FLAG_SCHEME_REQUIRED`**,**`FILTER_FLAG_HOST_REQUIRED`**,**`FILTER_FLAG_PATH_REQUIRED`**,**`FILTER_FLAG_QUERY_REQUIRED`**,**`FILTER_NULL_ON_FAILURE`**|Validates value as URL (according to [» http://www.faqs.org/rfcs/rfc2396](http://www.faqs.org/rfcs/rfc2396)), optionally with required components. Beware a valid URL may not specify the HTTP protocol `http://` so further validation may be required to determine the URL uses an expected protocol, e.g. `ssh://` or `mailto:`. Note that the function will only find ASCII URLs to be valid; internationalized domain names (containing non-ASCII characters) will fail.|

### SANITIZE FILTERS

|ID|Name|Flags|Description|
|---|---|---|---|
|**`FILTER_SANITIZE_EMAIL`**|"email"||Remove all characters except letters, digits and ``!#$%&'*+-=?^_`{\|}~@.[]``.|
|**`FILTER_SANITIZE_ENCODED`**|"encoded"|**`FILTER_FLAG_STRIP_LOW`**,**`FILTER_FLAG_STRIP_HIGH`**,**`FILTER_FLAG_STRIP_BACKTICK`**,**`FILTER_FLAG_ENCODE_LOW`**,**`FILTER_FLAG_ENCODE_HIGH`**|URL-encode string, optionally strip or encode special characters.|
|**`FILTER_SANITIZE_MAGIC_QUOTES`**|"magic_quotes"||Apply [addslashes()](https://www.php.net/manual/en/function.addslashes.php). (_DEPRECATED_ as of PHP 7.3.0 and _REMOVED_ as of PHP 8.0.0, use **`FILTER_SANITIZE_ADD_SLASHES`**instead.)|
|**`FILTER_SANITIZE_ADD_SLASHES`**|"add_slashes"||Apply [addslashes()](https://www.php.net/manual/en/function.addslashes.php). (Available as of PHP 7.3.0)|
|**`FILTER_SANITIZE_NUMBER_FLOAT`**|"number_float"|**`FILTER_FLAG_ALLOW_FRACTION`**,**`FILTER_FLAG_ALLOW_THOUSAND`**,**`FILTER_FLAG_ALLOW_SCIENTIFIC`**|Remove all characters except digits, `+-`and optionally `.,eE`.|
|**`FILTER_SANITIZE_NUMBER_INT`**|"number_int"||Remove all characters except digits, plus and minus sign.|
|**`FILTER_SANITIZE_SPECIAL_CHARS`**|"special_chars"|**`FILTER_FLAG_STRIP_LOW`**,**`FILTER_FLAG_STRIP_HIGH`**,**`FILTER_FLAG_STRIP_BACKTICK`**,**`FILTER_FLAG_ENCODE_HIGH`**|HTML-encode `'"<>&` and characters with ASCII value less than 32, optionally strip or encode other special characters.|
|**`FILTER_SANITIZE_FULL_SPECIAL_CHARS`**|"full_special_chars"|**`FILTER_FLAG_NO_ENCODE_QUOTES`**|Equivalent to calling [htmlspecialchars()](https://www.php.net/manual/en/function.htmlspecialchars.php)with **`ENT_QUOTES`** set. Encoding quotes can be disabled by setting **`FILTER_FLAG_NO_ENCODE_QUOTES`**. Like [htmlspecialchars()](https://www.php.net/manual/en/function.htmlspecialchars.php), this filter is aware of the [default_charset](https://www.php.net/manual/en/ini.core.php#ini.default-charset) and if a sequence of bytes is detected that makes up an invalid character in the current character set then the entire string is rejected resulting in a 0-length string. When using this filter as a default filter, see the warning below about setting the default flags to 0.|
|**`FILTER_SANITIZE_STRING`**|"string"|**`FILTER_FLAG_NO_ENCODE_QUOTES`**,**`FILTER_FLAG_STRIP_LOW`**,**`FILTER_FLAG_STRIP_HIGH`**,**`FILTER_FLAG_STRIP_BACKTICK`**,**`FILTER_FLAG_ENCODE_LOW`**,**`FILTER_FLAG_ENCODE_HIGH`**,**`FILTER_FLAG_ENCODE_AMP`**|Strip tags and HTML-encode double and single quotes, optionally strip or encode special characters. Encoding quotes can be disabled by setting **`FILTER_FLAG_NO_ENCODE_QUOTES`**. (_Deprecated_ as of PHP 8.1.0, use [htmlspecialchars()](https://www.php.net/manual/en/function.htmlspecialchars.php) instead.)|
|**`FILTER_SANITIZE_STRIPPED`**|"stripped"||Alias of "string" filter. (_Deprecated_ as of PHP 8.1.0, use [htmlspecialchars()](https://www.php.net/manual/en/function.htmlspecialchars.php)instead.)|
|**`FILTER_SANITIZE_URL`**|"url"||Remove all characters except letters, digits and ``$-_.+!*'(),{}\|\\^~[]`<>#%";/?:@&=``.|
|**`FILTER_UNSAFE_RAW`**|"unsafe_raw"|**`FILTER_FLAG_STRIP_LOW`**,**`FILTER_FLAG_STRIP_HIGH`**,**`FILTER_FLAG_STRIP_BACKTICK`**,**`FILTER_FLAG_ENCODE_LOW`**,**`FILTER_FLAG_ENCODE_HIGH`**,**`FILTER_FLAG_ENCODE_AMP`**|Do nothing, optionally strip or encode special characters. This filter is also aliased to **`FILTER_DEFAULT`**.|

### OTHER FILTERS


|ID|Name|Options|Flags|Description|
|---|---|---|---|---|
|**`FILTER_CALLBACK`**|"callback"|[callable](https://www.php.net/manual/en/language.types.callable.php) function or method|All flags are ignored|Call user-defined function to filter data.|