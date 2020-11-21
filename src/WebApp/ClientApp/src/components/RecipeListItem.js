import React from 'react';

export function RecipeListItem(props) {

    return (
        <a href={`/recipes/${props.id}`}>{props.name}</a>
    );

}
