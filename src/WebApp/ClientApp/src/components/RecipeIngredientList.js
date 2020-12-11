import React from 'react';
import { Row, Col, Container } from 'react-bootstrap';

import './RecipeIngredientList.css';

export function RecipeIngredientList(props) {

  const renderNotes = (notes) => !!notes && notes.length > 0 ? `(${notes.join(", ")})` : "";

  const renderRecipeIngredient = (ingredient, index) => (<Row key={index}>
    <Col className="recipe-ingredient-quantity">{ingredient.quantity} {ingredient.unit}</Col>
    <Col>{ingredient.name} <em>{renderNotes(ingredient.notes)}</em></Col>
  </Row>);

  return (
    <Container>
      <Row className="recipe-ingredient-list">Ingredients</Row>
      {props.ingredients.map(renderRecipeIngredient)}
    </Container>
  );
}