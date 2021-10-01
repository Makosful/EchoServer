# About

A simple HTTP echo box. It will echo whatever request is being sent to it, both HTTP and HTTPS.

The reply body of any request will contain the method of the quest, the path and query as a single string, the protocol and the host address.
Following that comes a list of headers, then finally the request body.

```http request
METHOD /path?query=true HTTP/1.1
Host: example.com
User-Agent: Your-Client/version
Content-Type: type/subtype
Accept: */*

This is where the request body would be. If I had any!
```