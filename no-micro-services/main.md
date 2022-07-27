% NoMicroServices
% Tomas Urbonaitis
% 2022-07-25

# About me
* 15+ years in the industry
* Mostly dotnet (but not anymore)
* Mostly backend distributed systems

# What are microservices? 
According to wikipedia:

> A microservice architecture – a variant of the SOA (service-oriented architecture) structural style – arranges an application as a collection of loosely-coupled services. In a microservices architecture, services are fine-grained and the protocols are lightweight.

# The lure
* Trendy! Cool!
* Uber/Google/Facebook and erveryone else does microservices!

# The advantages
* Fleixibility in technology/language choice
* Clear, explicit boundaries between components
* Small deployable units (scalability, fault tollerance)

# The Dark Side
* Complex system topology
* (highly) distributed system debugging
* More complex operations story
* Defining the service boundaries correctly is hard

# The Dark Side (continued)
* Much harder to refactor code
* Dependency management
* Less tooling maturity
* More IPC == poorer performance
* You get a whole new set of problems that monoliths just don't have to solve:
    * service discovery
    * versioning
    * inter service authN and authZ

# What to do?
* Start with a well structured monolith
* Carve out separate services when:
    * Domain is well understood
    * You are ready to invest in devops and tooling
    * You have the need to scale the components individually
    * You need to use different technologies/languages
* Some areas can be deployed as separate service from the very start (i.e. authentication)
