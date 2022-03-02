using System;
namespace VersioningService.Core.Interfaces
{
    public interface IDomainEventPublisher
    {
        //void Record(DomainEvent event);
        //void PublishRecorded();
        //void Publish(List<DomainEvent> events);
    }
}

/*
namespace CodelyTv\Shared\Domain\Bus\Event;

interface DomainEventPublisher
{
//Records events to be published afterwards using the publishRecorded method

public function record(DomainEvent...$domainEvents): void;


 // Publishes previously recorded events

public function publishRecorded(): void;


 //Immediately publishes the received events

public function publish(DomainEvent...$domainEvents);
} 
 */