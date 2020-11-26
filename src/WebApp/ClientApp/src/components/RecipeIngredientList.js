import React from 'react';
import { Row, Col, Container } from 'react-bootstrap';

import './RecipeIngredientList.css';

export function RecipeIngredientList(props) {

  const renderRecipeIngredient = (ingredient, index) => (<Row key={index}>
    <Col className="recipe-ingredient-quantity">{ingredient.quantity}</Col>
    <Col>{ingredient.name}</Col>
  </Row>);

  return (
    <Container>
      <Row className="recipe-ingredient-list">Ingredients</Row>
      {props.ingredients.map(renderRecipeIngredient)}
    </Container>
  );
}