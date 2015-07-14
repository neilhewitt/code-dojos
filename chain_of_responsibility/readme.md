Chain of Responsibility
=======================

This classic design pattern avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects 
and pass the request along the chain until an object handles it. 

Here's a real-world example which you should use as the basis of your implementation:

A business purchases items from suppliers using Purchase Orders. Each Purchase Order has a unique id, is for an amount (assume in Pounds Sterling only), has a supplier name, a description of the goods ordered,
a unit cost (again in Pounds) and a quantity. Assume a Purchase Order has only one item each.  

Purchase Orders can be approved by a Director, provided the total amount is <= £5000, the unit cost <= £1000, and the quantity is <= 100.

Otherwise, Purchase Orders can be approved by the CFO, provided the total amount is <= £50000, the unit cost <= £10000, and the quantity is <= 1000.

Otherwise, Purchase Orders must be approved by the CEO, provided the total amount is <= £500000.

Otherwise, a board meeting must be called and the Purchase Order must be approved by a Director, the CFO and the CEO.

Task: Create a program that allows budget holders to submit Purchase Orders for approval, offers it to each role for approval, passes it on if rejected, and reports back if it was approved and who approved it. 


