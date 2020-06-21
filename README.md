# Bussiness Rule Engine


Imagine you’re writing an order processing application for a large company. In the past, this company used a fairly random mixture of manual and ad-hoc automated business practices to handle orders; they now want to put all these various ways of hanadling orders together into one whole: your application. After a full day of workshops you have gathered the following set of rules which need to be managed by the new system.

If the payment is for a physical product, generate a packing slip for shipping.

If the payment is for a book, create a duplicate packing slip for the royalty department.

If the payment is for a membership, activate that membership.

If the payment is an upgrade to a membership, apply the upgrade.

If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.

If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip (the result of a court decision in 1997).

If the payment is for a physical product or a book, generate a commission payment to the agent.

Design a new system which can handle these rules and yet open to extension to new rules
