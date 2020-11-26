import React from 'react';
import { NavLink } from 'react-router-dom';

export function RecipeListItem(props) {

  return (
    <NavLink to={`/recipes/${props.id}`}> { props.name }</NavLink>
  );

}