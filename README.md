# NotificationSystemUsingRabbitMq

## What is RabbitMQ?
RabbitMQ is an open-source message broker software (sometimes called message-oriented middleware) that originally implemented the Advanced Message Queuing Protocol (AMQP) and has since been extended with a plug-in architecture to support other protocols. It acts as a mediator for communication, enabling applications to connect to each other as components of a larger system.

### Key Concepts

#### 1. Message Broker
- Acts as an intermediary for messaging
- Reduces the coupling between application components
- Ensures reliable message delivery
- Handles message routing and storage

#### 2. Core Components
- **Producer**: Application that sends messages
- **Consumer**: Application that receives messages
- **Queue**: Buffer that stores messages
- **Exchange**: Receives messages from producers and pushes them to queues
- **Binding**: Link between an exchange and a queue

#### 3. Exchange Types
- **Direct**: Routes messages to queues based on exact matching of routing keys
- **Topic**: Routes messages based on wildcard matching of routing keys
- **Fanout**: Broadcasts messages to all bound queues
- **Headers**: Routes based on message header attributes

### Key Features

1. **Reliability**
   - Message acknowledgments
   - Publisher confirms
   - High availability through clustering

2. **Flexibility**
   - Multiple messaging protocols support
   - Message routing capabilities
   - Priority queuing

3. **Security**
   - Authentication and authorization
   - TLS support
   - VHOST isolation

4. **Management & Monitoring**
   - HTTP-based API
   - Web-based UI
   - Command-line tools

### Message Flow
```mermaid
graph LR
    A[Producer] --> B[Exchange]
    B --> C[Queue]
    C --> D[Consumer]
