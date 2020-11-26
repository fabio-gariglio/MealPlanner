import React from 'react';
import { Row, Container } from 'react-bootstrap';

import './RecipeInstructionList.css'

export function RecipeInstructionList(props) {

  const renderInstruction = (instruction, index) => (<Row key={index}>
    <p>{instruction}</p>
  </Row>);

  return (
    <Container>
      <Row className="recipe-instruction-list">Instructions</Row>
      {props.instructions.map(renderInstruction)}
    </Container>
  );
}