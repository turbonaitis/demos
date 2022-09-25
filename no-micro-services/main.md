% NoMicroServices
% Tomas Urbonaitis
% 2022-07-25

## DISCLAIMER
All the content in this presentation is my own and does not represent the positions of my employers, past or present.

## About me
* 15+ years in the industry
* Mostly dotnet (but not anymore :( )
* Mostly backend distributed systems
* Microservices since 2012

::: notes

Started using microservices when they're still being called SOA.

Split monolith to microservices.

Created microservice-based green field solution. 

Worked in single language microservice systems and in multi-language microservice systems.

Worked in development roles and in more operational roles.

Worked in small startups that were doing microservices and in big companies that do microservices.

Still don't know everything. Or anthing :)

:::

## TLDR
* `NoMicroservices` like `NoSql`
* Are they bad? 
* Should I do them or not? 

::: notes

If you hope to hear some conclusive arguments against microservices - this is the wrong presentation.

NoMicroservices is like NoSQL - "Not only microservices". 

Are they always bad? Definitely not. Some companies can only succeed with microservices.

The real question is should you use them or not. And the answer is.... it depends :)

The goal is to discuss some of the tradeoffs and what one should have in mind especially with scaled microservices.

:::

## What are microservices? 
According to wikipedia:

> A microservice architecture – a variant of the SOA (service-oriented architecture) structural style – arranges an application as a collection of loosely-coupled services. In a microservices architecture, services are fine-grained and the protocols are lightweight.

::: notes

Who works on monoliths? 

Who works on microservices?

How many services does your system have?
- <10?
- 10-50?
- 50-100? 
- 100-1000? 
- 1000+?
- God knows? 

Languages:
- Single language? 
- Multiple languages?

:::

## Exhibit 1
![exhibit 1](images/microservices.png)

::: notes

So, as some people are already familiar with microservices, this will be easy :) 

Who here thinks this is microservices?

Not all the complexity captured here
- What fronts laod balanced microservices?
- How are they discovered?
- Local vs regional vs global

:::

## Exhibit 2
![exhibit 2](images/not-microservice.png)

::: notes

One could argue, but in general this is a microservice antipattern. 

There's no defined contract if you integrate via DB.

If anyone has successfully scaled such a solution - please talk to me after the presentation.

:::

## Exhibit 3
![exhibit 3](images/monolith.png)

::: notes

There's no trick here - it's just an old monolith

:::

## The lure
* Trendy! Cool!
* FAANG and everyone else does microservices!
* Sometimes (!) solve some actual problems

::: notes

So why do people chose to use microservices in the first place?

I was one of them! Let me tell you a story. I just left my previous job and was invited by a few ex-colleagues to join their greenfield startup. They've just raised seed capital for their idea and we now had to create a working product in half a year. We knew the market opportunity was there and were expecting immediate exponential growth. We were really familiar with microservices - the previous company we all worked at used them very successfully. Given the above, we decided to create a microservice based system from the beginning. Was that the right decision?

NO!

I'd say a lot of people do this because they're trendy and because FAANG companies use them (well, to be clear, no one knows what apple does, as they're so secretive :) ) 

i'm not saying it's everyone - some people are actually adressing some genuine needs by using microservices.

:::

## The advantages
* Enables large change volumes (organisational scalability)
* Clear, explicit boundaries between components
* Flexibility in technology/language choice
* Small deployable units (scalability, fault tolerance)

::: notes

Let's be optimists, let's look at the bright side of microservices first.

The biggest problem they're solving is not really tecnical, but organisational. When you have 100s or 1000s of developers and a monolith, what happens? 

You can also create clear and exlicit boundaries between components - there's clear data ownership, clear contracts and there have to be intentional changes.

If you want/need to use different languages/technologies (like dotnet and java) - monolith no longer works and so you have to go the microservice route. It also allows you to experiment with new technologies more freely, by writing a small new service in a new language.

The ability to deploy them individually of course brings benefits too - you can scale differently and if things go wrong, the blast radius is smaller. But this is a good segway onto our next section...

:::

## The Dark Side
* Complex system topology
* (highly) distributed system debugging
* Testing is more nuanced
* More complex operations story

::: notes

Even with moderate number of services, the system topology becomes complex. Which services depend on each other? Which are involved in what execution paths? Yes, there are tools to help answer these questions, but this is a problem monoliths simpy don't have.

This becomes a much bigger issue if the system doesn't behave as it should and you need to debug. Multiple services, potentially written using different technologies - the requirements on the observability stack suddenly become much higher.

So what do we do if we don't want to debug? Well, ideally we test our code :) 
The testing story becomes interesting. On one hand, your changes hopefully only touch only a service or two, so there's less to test, but when it comes to the system as a whole - how do you test that? Also, when in a single user journey, service boundaries are crossed multiple times, this expands the number of things that can fail - there are contract mismatches, degraded behavior of upstream and downstream dependencies etc to take into account. 

And observability is not the only operational aspect that becomes complicated - all operations are more difficult. In a monolith, all your system (except for the storage) is deployed in almost one go, there's much less need to think about ordering, backwards or forwards compatibility etc. Not any more. As there are more moving pieces, there are more things to be configured and the configuration is more dynamic.

:::

## The Dark Side (vol 2)
* Local development is more complicated
* Much harder to refactor code
* Less tooling maturity
* Dependency management

::: notes

While this applies to most big systems, even a reasonably small microservice system is more complicated when it comes to local development - do you build and deploy everything locally? That's a lot of building and deploying. Do you build and deploy only some parts? How do you manage the dependencies then? Do you connect to some shared environment? What happens if it breaks? Do you mock your dependencies? 

All systems evolve and that means refactoring. Let's say you want to rename a method. Or a field. In a monolith, you open the IDE, do the changes you want, build/test your code, commit and deploy - and you're done. If that name is exposed as part of your microservice API - you can't (or more precisely - it's a long and involved process). What about adding a parameter? Of course, but you need to take care of forwards and backwards compatibility first. And we haven't even gotten into different technologies, which means that tooling support is just not there.

And it's not just the refactoring - tooling around microservices is much less mature than around monoliths (although it's getting better in recent years). And you need more tooling :)

Then comes dependency management. We've already touched upon the fact that it may be hard to know what services are calling you. Why is that important? Imagine you want to change the behaviour of your service - you need to let your callers know. Or say you need a new method exposed by another service. You did all the negotiations and prioritetizations and your feature request has been implemented. Has it been deployed yet? Do you wait for it to be deployed? Great! Now it's deployed. You deploy your changes, only to discover after a week that your partner team rolled back their service to the previous version. Without the method that your service is calling. Nice.

:::

## The Dark Side (vol 3)
* More IPC == decreased performance
* You get a whole new set of problems that monoliths just don't have to solve:
    * service discovery
    * versioning
    * inter service authN and authZ
* all the above get harder with scale (product, organisational)

::: notes

If we have more interconnected components that means more IPC and regardless how fast your network is how well your collocation is working - IPC is slower than a method call within the same process. If you've messed up some part of your system design - it's MUCH slower. 

And there are other problems - how you discover your services? DNS? What about DNS caching? You either need to be super diligent with backwards and forwards compatibility, or get into the versioning game with it's own set of issues. You should do inter service authentication and authorization, if you're running a service mesh - but that brings even mroe tools into the picture. Tools that your teams needs to learn how to use and tools that are not perfect.

And if the company hasn't sunk under all these problems, if you've created a successful product and are growing - congratulations, most of the problems will get more complicated, eventually requiering dedicated teams to own them. 

:::

## What to do?
* Start with a well structured monolith
* Carve out separate services when:
    * Domain is well understood
    * You have people who have the expertise needed to develop and operate microservices
    * You are ready to invest in devops and tooling
    * You will benefit from the advantages

::: notes

So what do we do? Is it all doom and gloom? Should you stay away from microservices? 

Well, as I've said in the very beginning, it depends - on what stage of development your product is in (POC, first live version, mature old system, deprecated system), on the size of the company, the collective expertise that's present in the company etc.

If you're just starting out - KISS and start with a monolith. Quite likely time to market is more valuable than compelx architecture. 

Start thinking of microservices when you know the domain well, you have people (or at least can hire them) who have experience developing and operating microservices. You're ready to invest in devops practices and tooling. 

Most importantly though - when moving to microservices addresses a need, not a wish. 

:::

## In summary
* Any engineering solution is a compromise
* Choosing the correct solution has to take into account the context (and not just the technical context)
* It'll probably get worse before it gets better

## Thank you! 
https://urbonaitis.lt

http://linkedin.com/in/tomasurbonaitis/

https://github.com/turbonaitis
