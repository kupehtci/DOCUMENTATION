#AWS 

# AWS Config

**AWS Config** is a managed service that **records configuration changes** of your AWS resources over time.

It lets you **audit, evaluate, and monitor** whether your resource configurations comply with rules you define.


### AWS Config rules

**Config Rules** are compliance checks you define to evaluate resource configurations.

1. **Managed Rules**: Prebuilt by AWS (e.g., `required-tags`, `encrypted-volumes`, `restricted-ssh`).
2. **Custom Rules**: Written in AWS Lambda, where you define the logic to evaluate compliance.


Example managed rule:

- `required-tags` → ensures all EC2 instances, RDS DBs, and Redshift clusters have specific tags.
- `encrypted-volumes` → checks that all EBS volumes are encrypted.

When resources don’t comply, AWS Config marks them as **NON_COMPLIANT**.

## Typical AWS Exam Questions on AWS Config

Here are the **kinds of questions** you’ll see in a AWS Exam: 
1. **Tagging compliance**
    - Q: A company requires all resources to have an “Owner” and “Environment” tag. What’s the simplest way?
    - A: Use **AWS Config managed rule `required-tags`**.

2. **S3 bucket compliance**
    - Q: You need to ensure all S3 buckets are not publicly accessible.
    - A: Use **AWS Config managed rule** `s3-bucket-public-read-prohibited`.

3. **Encryption**
    - Q: Company requires all EBS volumes to be encrypted.
    - A: Use **AWS Config managed rule** `encrypted-volumes`.

4. **Integration with remediation**
    - Q: How do you automatically fix non-compliant resources?
    - A: Use **AWS Config with Systems Manager Automation documents (SSM documents)** for remediation.

5. **Audit requirements**
    - Q: Your security team must have a history of resource configuration changes for compliance.
    - A: Enable **AWS Config** to record configuration history.

