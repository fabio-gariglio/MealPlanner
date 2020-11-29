import React from 'react';
import { NavLink } from 'react-router-dom';
import { Row } from "react-bootstrap";

export function RecipeListItem(props) {

  return (
    <Row>
      <NavLink to={`/recipes/${props.id}`}> {props.name}</NavLink>
    </Row>
  );

}