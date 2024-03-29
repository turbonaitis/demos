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

## TLDR
* `NoMicroservices` like `NoSql`
* Are they bad? 
* Should I do them or not? 

## What are microservices? 
According to wikipedia:

> A microservice architecture – a variant of the SOA (service-oriented architecture) structural style – arranges an application as a collection of loosely-coupled services. In a microservices architecture, services are fine-grained and the protocols are lightweight.

## Exhibit 1
![exhibit 1](images/microservices.png)

## Exhibit 2
![exhibit 2](images/not-microservice.png)

## Exhibit 3
![exhibit 3](images/monolith.png)

## The lure
* Trendy! Cool!
* Uber/Google/Facebook and everyone else does microservices!

## The advantages
* Flexibility in technology/language choice
* Clear, explicit boundaries between components
* Small deployable units (scalability, fault tolerance)
* Enables large change volumes (organisational scalability)

## The Dark Side
* Complex system topology
* (highly) distributed system debugging
* More complex operations story
* Local development is more complicated

## The Dark Side (vol 2)
* Testing is more complicated
* Much harder to refactor code
* Dependency management
* Less tooling maturity

## The Dark Side (vol 3)
* More IPC == decreased performance
* You get a whole new set of problems that monoliths just don't have to solve:
    * service discovery
    * versioning
    * inter service authN and authZ
* all the above get harder with scale (product, organisational)

## What to do?
* Start with a well structured monolith
* Carve out separate services when:
    * Domain is well understood
    * You have people who have the expertise needed to develop and operate microservices
    * You are ready to invest in devops and tooling
    * You will benefit from the advantages
* Some areas can be deployed as separate service from the very start (i.e. authentication)

## In summary
* Any engineering solution is a compromise
* Choosing the correct solution has to take into account the context (and not just the technical context)
* It'll probably get worse before it gets better

## Thank you! 
https://urbonaitis.lt

http://linkedin.com/in/tomasurbonaitis/

https://github.com/turbonaitis
