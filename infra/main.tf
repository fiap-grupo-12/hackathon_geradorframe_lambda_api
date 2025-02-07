provider "aws" {
  region = "sa-east-1"
}

terraform {
  backend "s3" {
    bucket = "tfstate-grupo12-fiap-20251"
    key    = "lambda_api/terraform.tfstate"
    region = "sa-east-1"
  }
}


resource "aws_iam_role" "lambda_execution_role" {
  name = "lambda_api_execution_role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = "lambda.amazonaws.com"
        }
      },
    ]
  })
}

resource "aws_iam_policy" "lambda_policy" {
  name        = "lambda_api_policy"
  description = "IAM policy for Lambda execution"
  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "logs:CreateLogGroup",
          "logs:CreateLogStream",
          "logs:PutLogEvents",
          "dynamodb:DeleteItem",
          "dynamodb:GetItem",
          "dynamodb:PutItem",
          "dynamodb:Query",
          "dynamodb:Scan",
          "dynamodb:UpdateItem",
          "dynamodb:DescribeTable",
          "s3:PutObject",
        "s3:CreateBucket",
        "s3:GetObject",
        "s3:ListBucket"
        ]
        Resource = "*"
      }
    ]
  })
}

resource "aws_iam_role_policy_attachment" "lambda_execution_policy" {
  role       = aws_iam_role.lambda_execution_role.name
  policy_arn = aws_iam_policy.lambda_policy.arn
}

resource "aws_lambda_function" "api_function" {
  function_name = "lambda_api_function"
  role          = aws_iam_role.lambda_execution_role.arn
  runtime       = "dotnet8"
  memory_size   = 512
  timeout       = 30
  handler       = "FIAP.Hackathon.GeradorFrame.Lambda.API::FIAP.Hackathon.GeradorFrame.Lambda.API.LambdaEntryPoint::FunctionHandlerAsync"
  # Código armazenado no S3
  s3_bucket = "code-lambdas-functions-matsui1"
  s3_key    = "lambda_api_function.zip"
}
