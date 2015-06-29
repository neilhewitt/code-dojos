Reactor pattern
===============

The reactor design pattern is an event handling pattern for handling service requests delivered concurrently to a service handler by one or more inputs. The service handler then demultiplexes the incoming requests and dispatches them synchronously to the associated request handlers.

What this means, in practice, is that you need to provide an interface to one or more synchronous request handlers (basically, any old function) that can be called asynchronously, and which handles
the various callbacks and notifications to the asynchronous caller.

You need to create a handler (or set of handlers) that handles invocation of the target function/s, and a dispatcher that will take the incoming requests across multiple threads and de-multiplex them 
for handling by the handler. Then you need a reactor that reacts to the completion of execution of each request and notifies the caller in an idiomatic way.

Hint: async and await will help you here, but not as much as you'd think.




