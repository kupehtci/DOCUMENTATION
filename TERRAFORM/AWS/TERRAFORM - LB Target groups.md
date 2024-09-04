#AWS 

# AWS Load Balancer Target Groups


To create a Load Balancer Target group in terraform, follow the format depending on the type of Target Group we want to use[^1]: 

```hcl
resource "aws_lb_target_group" "ec2_target_group" {
  name     = "ec2-target-group"
  port     = 80
  protocol = "HTTP"
  vpc_id   = aws_vpc.main.id

  health_check {
    path                = "/health"
    interval            = 30
    timeout             = 5
    healthy_threshold   = 5
    unhealthy_threshold = 2
  }
}
```

For lambda target group, define: `target_type = "lambda"` and delete `port` and `protocol` parameters. 
For IP target group, define: `target_type = "ip"` and configure `port` and `protocol` properly. 

Next, you need to define a `aws_lb` resource for declaring the Load Balancer: 

```hcl
resource "aws_lb" "main" {
  name               = "main-lb"
  internal           = false
  load_balancer_type = "application"
  security_groups    = [aws_security_group.lb_sg.id]
  subnets            = [aws_subnet.public1.id, aws_subnet.public2.id]
}
```

Associate the target groups with a listener[^lis]. This resource checks for a connection on the specified port and protocol from the clients to the Load Balancer. 

When a request is received, redirects and routes the traffic to the appropriate target group based on the configure rules: 

```hcl
resource "aws_lb_listener" "http_listener" {
  load_balancer_arn = aws_lb.main.arn
  port              = 80
  protocol          = "HTTP"

  default_action {
    type             = "forward"
    target_group_arn = aws_lb_target_group.ec2_target_group.arn
  }
}
```

[^1]: There are three different target groups in AWS: Instance, IP and Lambda target groups [[AWS - ELB Target Groups]]
[^lis]: Load Balancer Listeners [[AWS - ELB Listeners]]