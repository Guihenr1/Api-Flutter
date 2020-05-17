import 'package:flutter/material.dart';

class AppText extends StatelessWidget {
  final text;
  final password;
  final controller;
  final FormFieldValidator<String> validate;
  final textInputType;
  final textInputAction;
  final focusNode;
  final nextFocus;

  AppText(this.text, { this.password: false, this.controller, this.validate, this.textInputType,
    this.textInputAction, this.focusNode, this.nextFocus });

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      controller: controller,
      obscureText: password,
      validator: validate,
      keyboardType: textInputType,
      textInputAction: textInputAction,
      focusNode: focusNode,
      onFieldSubmitted: (text) {
        if (nextFocus != null) {
          FocusScope.of(context).requestFocus(nextFocus);
        }
      },
      decoration: InputDecoration(labelText: text),
    );
  }
}